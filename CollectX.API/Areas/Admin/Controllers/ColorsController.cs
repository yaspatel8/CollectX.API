using CollectX.API.Application.Binders;
using CollectX.API.Application.Colors;
using CollectX.API.Common.Heplers;
using CollectX.API.Contracts.Colors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollectX.API.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ColorsController : ControllerBase
    {
        private readonly IColorsService _ColorsService;
        private readonly ILogger<ColorsController> _logger;

        public ColorsController(IColorsService colorsService, ILogger<ColorsController> logger)
        {
            _ColorsService = colorsService;
            _logger = logger;
        }

        [HttpPost("GetAllColors")]
        public async Task<ApiResponse<ColorsModel>> GetAllColors()
        {
            ApiResponse<ColorsModel> response = new();
            var result = await _ColorsService.GetAllColors();
            if (result == null || result.Count == 0)
            {
                response.Success = false;
                response.Message = "No colors found.";
                _logger.LogInformation("No colors found.");
                return response;
            }
            response.Success = true;
            response.Message = "Colors retrieved successfully.";
            response.Data = result;
            _logger.LogInformation("Colors retrieved successfully.");
            return response;
        }
    }
}
