using Microsoft.Extensions.DependencyInjection;
using UneContChallenge.Domain.Interfaces.Repositories;
using UneContChallenge.Infra.Repositories;

namespace UneContChallenge.CrossCutting
{
    public class DependencyInjector
    {
        public static void Register(IServiceCollection services)
        {
            // Repository
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<INotaFiscalRepository, NotaFiscalRepository>();

            //UnitOfWork
            services.AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
        }
    }
}
