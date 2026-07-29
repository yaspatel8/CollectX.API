using CollectX.API.Contracts.Binders;
using CollectX.API.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectX.API.Application.Binders
{
    public interface IBindersService
    {
        Task<ResponseModel> BindersSave(BindersRequestModel model);
        Task<ResponseModel> BindersDelete(int id, int updatedBy);
    }
}
