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
            var server = configuration["DbServer"] ?? "sqlserver";
            var port = configuration["DbPort"] ?? "1433"; 
            var user = configuration["DbUser"] ?? "SA"; 
            var password = configuration["Password"] ?? "Unecontchallenge@2024";
            var database = configuration["Database"] ?? "NotaFiscalDb";

            var connectionString = $"Server={server},{port};Initial Catalog={database};User ID={user};Password={password};TrustServerCertificate=True";

            services.AddDbContext<DataContexts>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }

        public static IServiceCollection AddAutoMapperConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}
