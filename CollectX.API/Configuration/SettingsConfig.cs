using CollectX.API.Contracts.Settings;

namespace CollectX.API.Configuration
{
    public static class SettingsConfig
    {
        public static IServiceCollection AddSettingsConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            //    services.Configure<DataConfig>(configuration.GetSection("Data"));
            //    services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.Configure<CorsSettings>(configuration.GetSection(CorsSettings.SectionName));
            return services;
        }
    }
}
