using CollectX.API.Common.Heplers;
using CollectX.API.Contracts.Common;
using CollectX.API.Contracts.Login;
using CollectX.API.Contracts.User;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
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
            // param.Add("@Password", loginRequest.Password);

            var result = await _db.QueryFirstOrDefaultAsync<LoginResponseModel>(StoredProcedures.SP_UserLogin, param, commandType: CommandType.StoredProcedure);
            return result;
        }
        public async Task<ResponseModel> ChangePassword(ChangePasswordRequestModel changePasswordRequest)
        {
            DynamicParameters param = new();
            param.Add("@UserId", changePasswordRequest.UserId);
            //param.Add("@OldPassword", changePasswordRequest.OldPassword);
            param.Add("@NewPassword", changePasswordRequest.NewPassword);
            var result = await _db.QueryFirstOrDefaultAsync<ResponseModel>(StoredProcedures.SP_ChangePassword, param, commandType: CommandType.StoredProcedure);
            return result;
        }
        public async Task<LoginResponseModel> GetUserDetails(int userId)
        {
            DynamicParameters param = new();
            param.Add("@UserId", userId);

            var result = await _db.QueryFirstOrDefaultAsync<LoginResponseModel>(StoredProcedures.SP_GetUserDetails, param, commandType: CommandType.StoredProcedure);
            return result;
        }
        public async Task<string> GetOldPassword(int userId)
        {
            DynamicParameters param = new();
            param.Add("@UserId", userId);
             
            var result = await _db.QueryFirstOrDefaultAsync<string>(StoredProcedures.SP_GetOldPassword,param,commandType: CommandType.StoredProcedure);
            return result;
        }
        public async Task<ProfileResponseModel> EditProfile(UserModel profileRequest)
        {
            DynamicParameters param = new();
            param.Add("@Id", profileRequest.Id);
            param.Add("@FirstName", profileRequest.FirstName);
            param.Add("@LastName", profileRequest.LastName);
            param.Add("@Email", profileRequest.Email);
            param.Add("@PhoneNumber", profileRequest.PhoneNumber);
            param.Add("@Image", profileRequest.ImagePath);
            param.Add("@Address", profileRequest.Address);
            param.Add("@UpdatedBy", profileRequest.UpdatedBy);
            param.Add("@OldFileName", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
            var result = await _db.QueryFirstOrDefaultAsync<ProfileResponseModel>(StoredProcedures.SP_EditProfile, param, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}
