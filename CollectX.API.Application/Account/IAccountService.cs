using CollectX.API.Contracts.Login;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectX.API.Application.Account
{
    public interface IAccountService
    {
        Task<LoginResponseModel> LoginUser(LoginRequestModel loginRequest);
    }
}
