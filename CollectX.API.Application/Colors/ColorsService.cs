using CollectX.API.Contracts.Colors;
using CollectX.API.Infrastructure.DBRepository.Colors;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectX.API.Application.Colors
{
    public class ColorsService : IColorsService
    {
        private readonly IColorsRepository _colorsRepository;
        public ColorsService(IColorsRepository colorsRepository)
        {
            _colorsRepository = colorsRepository;
        }

        public async Task<List<ColorsModel>> GetAllColors()
        {
            return await _colorsRepository.GetAllColors();
        }
    }
}
