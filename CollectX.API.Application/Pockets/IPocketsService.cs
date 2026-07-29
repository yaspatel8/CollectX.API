using CollectX.API.Contracts.Pockets;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectX.API.Application.Pockets
{
    public interface IPocketsService
    {
        Task<List<PocketsModel>> GetAll();
    }
}
