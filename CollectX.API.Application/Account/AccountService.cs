using CollectX.API.Contracts.Common;
using CollectX.API.Contracts.Login;
using CollectX.API.Infrastructure.DBRepository.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectX.API.Application.Account
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<LoginResponseModel> LoginUser(LoginRequestModel loginRequest)
        {
            return await _accountRepository.LoginUser(loginRequest);
        }
        public async Task<ResponseModel> ChangePassword(ChangePasswordRequestModel changePasswordRequest)
        {
            return await _accountRepository.ChangePassword(changePasswordRequest);
        }
        public async Task<LoginResponseModel> GetUserDetails(int userId)
        {
            return await _accountRepository.GetUserDetails(userId);
        }
    }
}
