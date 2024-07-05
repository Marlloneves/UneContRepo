using Microsoft.Extensions.DependencyInjection;
using UneContChallenge.Application.Interfaces;
using UneContChallenge.Application.Services;
using UneContChallenge.Domain.Interfaces.Repositories;
using UneContChallenge.Domain.Interfaces.Services;
using UneContChallenge.Domain.Services;
using UneContChallenge.Infra.Repositories;

namespace UneContChallenge.CrossCutting
{
    public class DependencyInjector
    {
        public static void Register(IServiceCollection services)
        {
            //AppService
            services.AddTransient<INotaFiscalAppService, NotaFiscalAppService>();

            //Domain
            services.AddTransient(typeof(IBaseDomainService<>), typeof(BaseDomainService<>));

            // Repository
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<INotaFiscalRepository, NotaFiscalRepository>();

            //UnitOfWork
            services.AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
        }
    }
}
