using CollectX.API.Contracts.Sets;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectX.API.Application.Sets
{
    public interface ISetsService
    {
        Task<List<SetsModel>> GetAll();
    }
}
