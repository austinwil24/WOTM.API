using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Converters;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Api.WorkoutTimeMachine
{
    public static class Setup
    {
        public const string DefaultCorsPolicy = "CorsPolicy";

        public static void AddLogging(IServiceCollection services, ILoggerFactory loggerFactory, IConfigurationRoot configuration)
        {
            loggerFactory.AddConsole(configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            services.AddScoped(x => loggerFactory.CreateLogger(Startup.ServiceName));
        }

        public static void ConfigureRepositories(IServiceCollection services)
        {

        }

        public static void ConfigureServices(IServiceCollection services)
        {

        }

        public static void ConfigureDataLayer(IServiceCollection services)
        {

        }

        public static void AddCors(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(DefaultCorsPolicy,
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod()
                               .AllowCredentials();
                    });
            });
        }

        public static void AddMvcCore(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddJsonFormatters(settings => settings.Converters.Add(new StringEnumConverter()))
                .AddApplicationPart(Assembly.Load("Api.WorkoutTimeMachine.Controllers"))
                .AddApiExplorer();
        }
    }
}