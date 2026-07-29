using CollectX.API.Application.Account;
using CollectX.API.Application.Binders;
using CollectX.API.Application.Colors;
using CollectX.API.Application.Pockets;
using CollectX.API.Application.Sets;
using CollectX.API.Infrastructure.DBRepository.Colors;

namespace CollectX.API.Application
{
    public static class ServiceRegister
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var serviceDictonary = new Dictionary<Type, Type>
            {
                 {typeof(IAccountService),typeof(AccountService) },
                {typeof (IBindersService),typeof(BindersService)  },
                {typeof (IColorsService),typeof(ColorsService)  },
                {typeof (ISetsService),typeof(SetsService)  },
                {typeof  (IPocketsService),typeof(PocketsService)  },
            };
            return serviceDictonary;
        }
    }
}
