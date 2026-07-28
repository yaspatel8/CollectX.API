using CollectX.API;
using CollectX.API.Configuration;
using CollectX.API.Middleware;
using Microsoft.Data.SqlClient;
using NLog;
using NLog.Web;
using System.Data;

var builder = WebApplication.CreateBuilder(args);
var logger = LogManager.Setup()
                       .LoadConfigurationFromFile("nlog.config")
                       .GetCurrentClassLogger();

// Add services to the container.

builder.Logging.ClearProviders();
builder.Host.UseNLog();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi


builder.Services.AddOpenApiConfiguration(builder.Configuration);
builder.Services.AddOpenApi();
builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(builder.Configuration.GetConnectionString("ConnectDB")));
builder.Services.RegisterServices();
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    // CRUCIAL: This executes your custom Swagger, Scalar, and ReDoc middleware definitions
//    app.UseOpenApiConfiguration();
//}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseOpenApiConfiguration();
app.MapControllers();

app.Run();
