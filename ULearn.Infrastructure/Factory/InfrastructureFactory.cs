using CsvWorker.infrastructure.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace CsvWorker.infrastructure.Factory
{
    public class InfrastructureFactory
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped<IConfigurationSettings, ConfigurationSettings>();
        }
    }
}
