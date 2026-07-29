using CollectX.API.Contracts.Colors;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectX.API.Application.Colors
{
    public interface IColorsService
    {
        Task<List<ColorsModel>> GetAllColors();
    }
}
