using CollectX.API.Common.Heplers;
using CollectX.API.Contracts.Pockets;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CollectX.API.Infrastructure.DBRepository.Pockets
{
    public class PocketsRepository : IPocketsRepository
    {
        public readonly IDbConnection _db;

        public PocketsRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<List<PocketsModel>> GetAll()
        {
            var result = await _db.QueryAsync<PocketsModel>(StoredProcedures.SP_PocketsGetAll, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
