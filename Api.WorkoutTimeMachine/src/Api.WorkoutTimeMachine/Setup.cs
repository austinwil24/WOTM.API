using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;
using System.Reflection;

namespace Api.WorkoutTimeMachine
{
    public static class Setup
    {
        public static string DefaultCorsPolicy { get; } = "CorsPolicy";

        public static void AddLogging(IServiceCollection services)
        {
            
        }

        public static void AddX(IServiceCollection services)
        {

        }

        public static void AddY(IServiceCollection services)
        {

        }

        public static void AddZ(IServiceCollection services)
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