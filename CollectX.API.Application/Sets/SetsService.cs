using CollectX.API.Contracts.Sets;
using CollectX.API.Infrastructure.DBRepository.Sets;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectX.API.Application.Sets
{
    public class SetsService : ISetsService
    {
        private readonly ISetsRepository _setsRepository;
        public SetsService(ISetsRepository setsRepository)
        {
            _setsRepository = setsRepository;
        }
        public async Task<List<SetsModel>> GetAll()
        {
            return await _setsRepository.GetAll();
        }
    }
}
