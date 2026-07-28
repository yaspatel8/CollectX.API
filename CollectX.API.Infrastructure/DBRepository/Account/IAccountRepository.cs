using CollectX.API.Contracts.Login;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectX.API.Infrastructure.DBRepository.Account
{
    public interface IAccountRepository
    {
        Task<LoginResponseModel> LoginUser (LoginRequestModel loginRequest);
    }
}
