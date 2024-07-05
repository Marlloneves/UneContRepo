using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UneContChallenge.Infra.Contexts;

namespace UneContChallenge.CrossCutting
{
    public static class ExtensionIOC
    {
        public static IServiceCollection AddSqlServerConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("UneContSettings");

            services.AddDbContext<DataContexts>(options => options.UseSqlServer(connectionString));

            return services;
        }

        public static IServiceCollection AddAutoMapperConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}
