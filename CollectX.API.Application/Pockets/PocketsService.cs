using CollectX.API.Contracts.Pockets;
using CollectX.API.Infrastructure.DBRepository.Pockets;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectX.API.Application.Pockets
{
    public class PocketsService : IPocketsService
    {
        private readonly IPocketsRepository _pocketsRepository;
        public PocketsService(IPocketsRepository pocketsRepository)
        {
            _pocketsRepository = pocketsRepository;
        }
        public async Task<List<PocketsModel>> GetAll()
        {
            return await _pocketsRepository.GetAll();
        }
    }
}
