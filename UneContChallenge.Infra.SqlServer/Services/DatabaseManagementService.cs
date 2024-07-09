using Microsoft.AspNetCore.Builder;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UneContChallenge.Infra.Contexts;

namespace UneContChallenge.Infra.Services
{
    public static class DatabaseManagementService
    {
        public static void MigrationInitialisation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DataContexts>();
                var maxRetries = 5;
                var retries = 0;

                while (retries < maxRetries)
                {
                    try
                    {
                        if (context.Database.GetDbConnection().State == System.Data.ConnectionState.Closed)
                        {
                            context.Database.GetDbConnection().Open();
                        }

                        context.Database.Migrate();
                        break;
                    }
                    catch (SqlException)
                    {
                        retries++;
                        System.Threading.Thread.Sleep(2000);
                    }
                }
            }
        }

    }
}
