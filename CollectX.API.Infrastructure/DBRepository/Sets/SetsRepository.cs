using CollectX.API.Common.Heplers;
using CollectX.API.Contracts.Sets;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CollectX.API.Infrastructure.DBRepository.Sets
{
    public class SetsRepository : ISetsRepository
    {
        private readonly IDbConnection _db;
        public SetsRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<List<SetsModel>> GetAll()
        {
            var result = await _db.QueryAsync<SetsModel>(StoredProcedures.SP_SetsGetAll, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
