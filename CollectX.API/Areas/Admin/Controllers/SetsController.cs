using CollectX.API.Application.Sets;
using CollectX.API.Common.Heplers;
using CollectX.API.Contracts.Sets;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollectX.API.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SetsController : ControllerBase
    {
        private readonly ISetsService _setsService;
        private readonly ILogger<SetsController> _logger;
        public SetsController(ISetsService setsService, ILogger<SetsController> logger)
        {
            _setsService = setsService;
            _logger = logger;
        }
        
        [HttpPost("GetAllSets")]
        public async Task<ApiResponse<SetsModel>> GetAllSets()
        {
            ApiResponse<SetsModel> response = new();
            var result = await _setsService.GetAll();

            if (result == null || result.Count == 0)
            {
                response.Success = false;
                response.Message = "No sets found.";
                _logger.LogInformation("No sets found.");
                return response;
            }
            response.Success = true;
            response.Data = result;
            response.Message = "Sets retrieved successfully.";
            _logger.LogInformation("Sets retrieved successfully.");
            return response;
        }
    }
}
