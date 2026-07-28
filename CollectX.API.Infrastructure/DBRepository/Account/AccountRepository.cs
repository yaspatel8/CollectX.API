using CollectX.API.Common.Heplers;
using CollectX.API.Contracts.Login;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CollectX.API.Infrastructure.DBRepository.Account
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IDbConnection _db;

        public AccountRepository(IDbConnection db)
        {
            _db = db;
            
        }

        public async Task<LoginResponseModel> LoginUser(LoginRequestModel loginRequest)
        {
            DynamicParameters param = new();
            param.Add("@Email", loginRequest.Email);
            param.Add("@Password", loginRequest.Password);

            var result = await _db.QueryFirstOrDefaultAsync<LoginResponseModel>(StoredProcedures.SP_UserLogin, param, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}
