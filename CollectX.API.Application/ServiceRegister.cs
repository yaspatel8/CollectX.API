using CollectX.API.Application.Account;

namespace CollectX.API.Application
{
    public static class ServiceRegister
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var serviceDictonary = new Dictionary<Type, Type>
            {
                 {typeof(IAccountService),typeof(AccountService) },
            };
            return serviceDictonary;
        }
    }
}
