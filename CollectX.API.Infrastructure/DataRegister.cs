using CollectX.API.Infrastructure.DBRepository.Account;
using CollectX.API.Infrastructure.DBRepository.Binders;
using CollectX.API.Infrastructure.DBRepository.Colors;
using CollectX.API.Infrastructure.DBRepository.Pockets;
using CollectX.API.Infrastructure.DBRepository.Sets;

namespace CollectX.API.Infrastructure
{
    public static class DataRegister
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var dataDictionary = new Dictionary<Type, Type>
            {
                { typeof(IAccountRepository), typeof(AccountRepository) },
                { typeof(IBindersRepository), typeof(BindersRepository)  },
                {typeof (IColorsRepository),typeof(ColorsRepository) },
                {typeof(ISetsRepository),typeof(SetsRepository) },
                {typeof(IPocketsRepository),typeof(PocketsRepository) },

            };
            return dataDictionary;
        }

    }
}
