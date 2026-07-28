using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Scalar.AspNetCore;
using System.Text;

namespace CollectX.API.Configuration
{
    public static class OpenApiConfig
    {
        public static void AddOpenApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,

                       ValidIssuer = configuration["Jwt:Issuer"],
                       ValidAudience = configuration["Jwt:Audience"],
                       IssuerSigningKey = new SymmetricSecurityKey(
                           Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))
                   };
               });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "CollectX API NEW",
                    Version = "v1",
                    Description = "API for managing CollectX data"
                });

                c.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        Description = "JWT Authorization header using the Bearer scheme.",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer",
                        BearerFormat = "JWT"
                    });

                c.AddSecurityRequirement(document => new OpenApiSecurityRequirement
                {
                    [new OpenApiSecuritySchemeReference("Bearer", document)] = []
                });
            });
        }

        public static void UseOpenApiConfiguration(this WebApplication app)
        {
            app.MapOpenApi();

            //Swagger 

            app.UseSwagger(c =>
            {
                c.RouteTemplate = "openapi/{documentName}.json";
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/openapi/v1.json", "CollectX API NEW");
                c.RoutePrefix = "swagger"; // Set Swagger UI at the app's root
            });

            //Scalar API
            app.MapScalarApiReference(c =>
            {
                c.WithTitle("CollectX API NEW");
                c.WithTheme(ScalarTheme.Kepler);
                c.WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
            });

            //ReDoc
            app.UseReDoc(c =>
            {
                c.RoutePrefix = "redoc"; // Set ReDoc UI at the app's root
                c.DocumentTitle = "CollectX API NEW Documentation";
                c.SpecUrl("/openapi/v1.json");
            });
        }
    }
}