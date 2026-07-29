using CollectX.API.Application.Account;
using CollectX.API.Application.Binders;
using CollectX.API.Common.Heplers;
using CollectX.API.Contracts.Binders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static CollectX.API.Common.Enum.CommonEnums;

namespace CollectX.API.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BindersController : ControllerBase
    {
        private readonly IBindersService _BindersService;
        private readonly ILogger<BindersController> _logger;
        
        public BindersController(IBindersService bindersService, ILogger<BindersController> logger)
        {
            _BindersService = bindersService;
            _logger = logger;
        }

        [HttpPost("BindersSave")]
        public async Task<BaseApiResponse> BindersSave(BindersRequestModel model)
        {
            BaseApiResponse response = new ();

            int UserId = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value != null ? Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value) : 0;
            model.CreatedBy = UserId;

            var result = await _BindersService.BindersSave(model);
           
            if (result.Success == (int)ResponseStatus.AlreadyExists)
            {
                response.Success = false;
                response.Message = result.Message;
                _logger.LogInformation("Binders save failed. Reason: {Message}.", result.Message);
                return response;
            }
            else if (result.Success != (int)ResponseStatus.Success)
            {
                response.Success = false;
                response.Message = result.Message;
                _logger.LogInformation("Binders save failed. Reason: {Message}.", result.Message);
                return response;
            }
            else
            {
                response.Success = true;
                response.Message = result.Message;
                _logger.LogInformation("Binders saved successfully.");
                return response;
            }
        }

        [HttpDelete("BindersDelete")]
        public async Task<BaseApiResponse> BindersDelete(int id)
        {
            BaseApiResponse response = new();
            int UserId = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value != null ? Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value) : 0;
            var result = await _BindersService.BindersDelete(id, UserId);
            if (result.Success != (int)ResponseStatus.Success)
            {
                response.Success = false;
                response.Message = result.Message;
                _logger.LogInformation("Binders delete failed. Reason: {Message}.", result.Message);
                return response;
            }
            else
            {
                response.Success = true;
                response.Message = result.Message;
                _logger.LogInformation("Binders deleted successfully.", result.Message);
                return response;
            }
        }
    }
}
