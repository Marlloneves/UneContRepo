using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace UneContChallenge.Infra.Contexts
{
    public class DataContextMigration : IDesignTimeDbContextFactory<DataContexts>
    {
        public DataContexts CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.infra.json");
            config.AddJsonFile(path, false);

            var root = config.Build();
            var connectionString = root.GetSection("ConnectionStrings").GetSection("UneContSettings").Value;

            var builder = new DbContextOptionsBuilder<DataContexts>();
            builder.UseSqlServer(connectionString);

            return new DataContexts(builder.Options);
        }
    }
}
