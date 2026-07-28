using CollectX.API.Application.Account;
using CollectX.API.Common.Heplers;
using CollectX.API.Contracts.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        public AccountController(IAccountService accountService, ILogger<AccountController> logger)
        {
            _accountService = accountService;
            _logger = logger;
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ApiPostResponse<LoginResponseModel>> LoginUser(LoginRequestModel loginRequest)
        {
            ApiPostResponse<LoginResponseModel> response = new();

            var result = await _accountService.LoginUser(loginRequest);

            if(result.Success != (int)ResponseStatus.Success)
            {
                response.Success = false;
                response.Message = result.Message;
                _logger.LogInformation("Login failed for user with email: {Email}.", loginRequest.Email, result.Message);
            }
            else
            {
                response.Success = true;
                response.Message = result.Message;
                response.Data = result;
                _logger.LogInformation("Login successful for user with email: {Email}.", loginRequest.Email);
            }
            return response;
        }
    }
}
