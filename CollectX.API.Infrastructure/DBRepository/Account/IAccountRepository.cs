using CollectX.API.Common.Heplers;
using CollectX.API.Contracts.Common;
using CollectX.API.Contracts.Login;
using CollectX.API.Contracts.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectX.API.Infrastructure.DBRepository.Account
{
    public interface IAccountRepository
    {
        Task<LoginResponseModel> LoginUser (LoginRequestModel loginRequest);
        Task<ResponseModel> ChangePassword(ChangePasswordRequestModel changePasswordRequest); 
        Task<LoginResponseModel> GetUserDetails(int userId);
        Task<string> GetOldPassword(int UserId);
        Task<ProfileResponseModel> EditProfile(UserModel profileRequest);
    }
}
