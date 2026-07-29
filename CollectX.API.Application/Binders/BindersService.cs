using CollectX.API.Contracts.Binders;
using CollectX.API.Contracts.Common;
using CollectX.API.Infrastructure.DBRepository.Binders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectX.API.Application.Binders
{
    public class BindersService : IBindersService
    {
        private readonly IBindersRepository _bindersRepository;
        public BindersService(IBindersRepository bindersRepository)
        {
            _bindersRepository = bindersRepository;
        }

        public async Task<ResponseModel> BindersSave(BindersRequestModel model)
        {
            return await _bindersRepository.BindersSave(model);
        }
        public async Task<ResponseModel> BindersDelete(int id, int updatedBy)
        {
            return await _bindersRepository.BindersDelete(id, updatedBy);
        }
    }
}
