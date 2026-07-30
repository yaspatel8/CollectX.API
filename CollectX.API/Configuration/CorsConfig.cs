using CollectX.API.Contracts.Settings;

namespace CollectX.API.Configuration
{
    public static class CorsConfig
    {
        public const string DefaultPolicyName = "AllowRequests";

        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var corsSettings = configuration.GetSection(CorsSettings.SectionName).Get<CorsSettings>()
                ?? throw new InvalidOperationException(
                    $"{CorsSettings.SectionName} section is missing from configuration.");

            if (corsSettings.AllowedOrigins is not { Length: > 0 })
            {
                throw new InvalidOperationException(
                  $"{CorsSettings.SectionName}:AllowedOrigins must contain at least one origin.");
            }

            services.AddCors(options =>
            {
                options.AddPolicy(DefaultPolicyName, builder =>
                {
                    builder.WithOrigins(corsSettings.AllowedOrigins)
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowCredentials();
                });
            });
            return services;
        }
    }
}
