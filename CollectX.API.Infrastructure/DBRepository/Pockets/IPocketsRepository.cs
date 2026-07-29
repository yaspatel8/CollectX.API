using CollectX.API.Contracts.Pockets;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectX.API.Infrastructure.DBRepository.Pockets
{
    public interface IPocketsRepository
    {
        Task<List<PocketsModel>> GetAll();
    }
}
