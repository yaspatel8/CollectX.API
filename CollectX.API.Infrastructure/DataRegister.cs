using CollectX.API.Infrastructure.DBRepository.Account;

namespace CollectX.API.Infrastructure
{
    public static class DataRegister
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var dataDictionary = new Dictionary<Type, Type>
            {
                { typeof(IAccountRepository), typeof(AccountRepository) },

            };
            return dataDictionary;
        }

    }
}
