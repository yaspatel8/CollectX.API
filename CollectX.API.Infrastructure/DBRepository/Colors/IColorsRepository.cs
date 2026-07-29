using CollectX.API.Contracts.Colors;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectX.API.Infrastructure.DBRepository.Colors
{
    public interface IColorsRepository
    {
        Task<List<ColorsModel>> GetAllColors();
    }
}
