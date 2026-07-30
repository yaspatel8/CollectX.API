using CollectX.API.Application.Account;
using CollectX.API.Common.CommonMethod;
using CollectX.API.Common.Heplers;
using CollectX.API.Contracts.Login;
using CollectX.API.Contracts.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using static CollectX.API.Common.Enum.CommonEnums;

namespace CollectX.API.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ILogger<AccountController> _logger;
        private readonly IConfiguration _configuration;
        private readonly PasswordHasher<IdentityUser> _passwordHasher;
        private readonly IWebHostEnvironment _environment;

        public AccountController(IAccountService accountService, ILogger<AccountController> logger, IConfiguration configuration, PasswordHasher<IdentityUser> passwordHasher, IWebHostEnvironment environment)
        {
            _accountService = accountService;
            _logger = logger;
            _configuration = configuration;
            _passwordHasher = passwordHasher;
            _environment = environment;
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ApiPostResponse<dynamic>> LoginUser(LoginRequestModel loginRequest)
        {
            ApiPostResponse<dynamic> response = new();

            var result = await _accountService.LoginUser(loginRequest);

            if (result.Success != (int)ResponseStatus.Success)
            {
                response.Success = false;
                response.Message = result.Message;

                _logger.LogInformation("Login failed for user with email: {Email}.", loginRequest.Email, result.Message);
                return response;
            }

            bool isPasswordValid = _passwordHasher.VerifyHashedPassword(new IdentityUser(), result.Password, loginRequest.Password) == PasswordVerificationResult.Success;

            if (!isPasswordValid)
            {
                response.Success = false;
                response.Message = "Invalid password.";
                _logger.LogInformation("Login failed for user with email: {Email}. Invalid password.", loginRequest.Email);
                return response;
            }

            response.Success = true;
            response.Message = result.Message;

            string token = CommonMethods.GenerateToken(result.UserId, loginRequest.Email, result.Role, _configuration["Jwt:Key"]);
            response.Data = token;

            _logger.LogInformation("Login successful for user with email: {Email}.", loginRequest.Email);
            return response;
        }
        [HttpPost("ChangePassword")]
        public async Task<ApiPostResponse<dynamic>> ChangePassword(ChangePasswordRequestModel changePasswordRequest)
        {
            ApiPostResponse<dynamic> response = new();
            int UserId = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value != null ? Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value) : 0;
            changePasswordRequest.UserId = UserId;

            var oldPassword = await _accountService.GetOldPassword(UserId);

            bool isPasswordValid = _passwordHasher.VerifyHashedPassword(new IdentityUser(), oldPassword, changePasswordRequest.OldPassword) == PasswordVerificationResult.Success;
            if(!isPasswordValid)
            {
                response.Success = false;
                response.Message = "Invalid Old Password";
                _logger.LogInformation("Invalid Old Password", changePasswordRequest.UserId);
                return response;
            }

            string NewPassowrdHash = _passwordHasher.HashPassword(new IdentityUser(), changePasswordRequest.NewPassword);
            changePasswordRequest.NewPassword = NewPassowrdHash;

            var result = await _accountService.ChangePassword(changePasswordRequest);

            if (result.Success != (int)ResponseStatus.Success)
            {
                response.Success = false;
                response.Message = result.Message;

                _logger.LogInformation("{message}", changePasswordRequest.UserId, result.Message);
                return response;
            }

            response.Success = true;
            response.Message = result.Message;

            _logger.LogInformation("{message}", changePasswordRequest.UserId, result.Message);
            return response;
        }
        [HttpPost("GetUserDetails")]
        public async Task<ApiPostResponse<dynamic>> GetUserDetails()
        {
            ApiPostResponse<dynamic> response = new();
            int UserId = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value != null ? Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value) : 0;
            var result = await _accountService.GetUserDetails(UserId);
            if (result == null)
            {
                response.Success = false;
                response.Message = "User not found.";
                _logger.LogInformation("GetUserDetails failed for user with ID: {UserId}.", UserId);
                return response;
            }
            response.Success = true;
            response.Message = "User details retrieved successfully.";
            response.Data = result;
            _logger.LogInformation("GetUserDetails successful for user with ID: {UserId}.", UserId);
            return response;
        }

        [HttpPost("EditProfile")]
        public async Task<ApiPostResponse<dynamic>> EditProfile(UserModel model)
        {
            ApiPostResponse<dynamic> response = new();
            int UserId = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value != null ? Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value) : 0;
            model.Id = UserId;
            model.UpdatedBy = UserId;

            // Upload folder
            string uploadsFolder = Path.Combine(_environment.WebRootPath, "ProfileImages");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            // File Upload
            if (model.ProfileImage != null)
            {
                string extension = Path.GetExtension(model.ProfileImage.FileName).ToLower();

                string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };

                if (!allowedExtensions.Contains(extension))
                {
                    response.Success = false;
                    response.Message = "Only jpg, jpeg and png files are allowed.";

                    return response;
                }
                const long maxFileSize = 2 * 1024 * 1024;

                if (model.ProfileImage.Length > maxFileSize)
                {
                    response.Success = false;
                    response.Message = "Maximum image size is 2 MB.";

                    return response;
                }

                // Generate unique filename
                string uniqueFileName = $"{Guid.NewGuid()}{extension}";

                string filePath = Path.Combine(uploadsFolder, uniqueFileName);


                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.ProfileImage.CopyToAsync(stream);
                }

                model.ImagePath = uniqueFileName;
            }

            var result = await _accountService.EditProfile(model);


            if (result.Success == (int)ResponseStatus.Success)
            {

                // Delete old image after successful update
                if (model.Id > 0 && !string.IsNullOrEmpty(result.OldFileName) && model.ProfileImage != null)
                {
                    string oldPath = Path.Combine(uploadsFolder, result.OldFileName);

                    if (System.IO.File.Exists(oldPath))
                    {
                        try
                        {
                            System.IO.File.Delete(oldPath);
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex.Message);
                        }
                    }
                }
                response.Success = true;
                response.Message = result.Message;
                _logger.LogInformation(result.Message, result);
            }
            else if (result.Success == (int)ResponseStatus.AlreadyExists)
            {
                response.Success = false;
                response.Message = result.Message;
                _logger.LogWarning(result.Message, result);
            }
            else
            {
                // SP failed, delete newly uploaded image
                if (!string.IsNullOrEmpty(model.ImagePath))
                {
                    string newPath = Path.Combine(uploadsFolder, model.ImagePath);

                    if (System.IO.File.Exists(newPath))
                    {
                        System.IO.File.Delete(newPath);
                    }
                }
                response.Success = false;
                response.Message = result.Message;
                _logger.LogWarning(result.Message, result);
            }
            return response;
        }
    }
}
