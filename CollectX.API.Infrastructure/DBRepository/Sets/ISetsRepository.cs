using CollectX.API.Contracts.Sets;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectX.API.Infrastructure.DBRepository.Sets
{
    public interface ISetsRepository
    {
        Task<List<SetsModel>> GetAll();
    }
}
