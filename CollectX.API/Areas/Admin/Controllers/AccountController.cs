using CollectX.API.Application.Account;
using CollectX.API.Common.CommonMethod;
using CollectX.API.Common.Heplers;
using CollectX.API.Contracts.Login;
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

        public AccountController(IAccountService accountService, ILogger<AccountController> logger, IConfiguration configuration, PasswordHasher<IdentityUser> passwordHasher)
        {
            _accountService = accountService;
            _logger = logger;
            _configuration = configuration;
            _passwordHasher = passwordHasher;
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

    }
}
