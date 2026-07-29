using CollectX.API.Common.Heplers;
using CollectX.API.Contracts.Binders;
using CollectX.API.Contracts.Common;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CollectX.API.Infrastructure.DBRepository.Binders
{
    public class BindersRepository : IBindersRepository
    {
        private readonly IDbConnection _db;

        public BindersRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<ResponseModel> BindersSave(BindersRequestModel model)
        {
            DynamicParameters param = new();
            param.Add("@Id", model.Id);
            param.Add("@BinderName", model.BinderName);
            param.Add("@ColorId",model.ColorId);
            param.Add("@PocketId", model.PocketId);
            param.Add("@SetId", model.SetId);
            param.Add("@Sku", model.Sku);
            param.Add("@IsNFC", model.IsNFC);
            param.Add("@CreatedBy", model.CreatedBy);

            var result = await _db.QueryFirstOrDefaultAsync<ResponseModel>(StoredProcedures.SP_BindersSave, param, commandType: CommandType.StoredProcedure);
            return result;
        }

        public async Task<ResponseModel> BindersDelete(int id, int updatedBy)
        {
            DynamicParameters param = new();
            param.Add("@Id", id);
            param.Add("@CreatedBy", updatedBy);

            var result = await _db.QueryFirstOrDefaultAsync<ResponseModel>(StoredProcedures.SP_BinderDelete, param, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}
