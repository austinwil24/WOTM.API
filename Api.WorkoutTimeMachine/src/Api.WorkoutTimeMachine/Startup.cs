using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Api.WorkoutTimeMachine
{
    public class Startup
    {
        public const string ServiceName = "Api.WorkoutTimeMachine";

        public ILoggerFactory LoggerFactory { get; }

        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, false)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();

            LoggerFactory = loggerFactory;

            Configuration = builder.Build();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseCors(Setup.DefaultCorsPolicy);

            app.UseMvc();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            Setup.AddLogging(services, LoggerFactory, Configuration);

            Setup.AddCors(services);

            Setup.ConfigureDataLayer(services);

            Setup.ConfigureRepositories(services);

            Setup.ConfigureServices(services);

            Setup.AddMvcCore(services);
        }
    }
}
