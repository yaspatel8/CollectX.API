using CollectX.API.Application.Pockets;
using CollectX.API.Common.Heplers;
using CollectX.API.Contracts.Pockets;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollectX.API.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PocketsController : ControllerBase
    {
        private readonly IPocketsService _pocketsService;
        private readonly ILogger<PocketsController> _logger;
        public PocketsController(IPocketsService pocketsService, ILogger<PocketsController> logger)
        {
            _pocketsService = pocketsService;
            _logger = logger;
        }
        [HttpPost("GetAllPockets")]
        public async Task<ApiResponse<PocketsModel>> GetAll()
        {
            ApiResponse<PocketsModel> response = new();

            var result = await _pocketsService.GetAll();
            if(result == null || result.Count == 0)
            {
                response.Success = false;
                response.Message = "No pockets found.";
                _logger.LogInformation("No pockets found.");
                return response;
            }
            response.Success = true;
            response.Message = "Pockets retrieved successfully.";
            response.Data = result;
            _logger.LogInformation("Pockets retrieved successfully.");
            return response;
        }
    }
}
