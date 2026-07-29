using CollectX.API.Common.Heplers;
using CollectX.API.Contracts.Colors;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CollectX.API.Infrastructure.DBRepository.Colors
{
    public class ColorsRepository : IColorsRepository
    {
        private readonly IDbConnection _db;
        public ColorsRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<List<ColorsModel>> GetAllColors()
        {
            var result = await _db.QueryAsync<ColorsModel>(StoredProcedures.SP_ColorsGetAll, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
