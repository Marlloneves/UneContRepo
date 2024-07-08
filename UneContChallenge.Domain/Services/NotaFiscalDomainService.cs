using UneContChallenge.Domain.Entities;
using UneContChallenge.Domain.Interfaces.Repositories;
using UneContChallenge.Domain.Interfaces.Services;

namespace UneContChallenge.Domain.Services
{
    public class NotaFiscalDomainService : BaseDomainService<NotaFiscal>, INotaFiscalDomainService
    {
        private readonly IUnitOfWork<NotaFiscal> _unitOfWork;

        public NotaFiscalDomainService(IUnitOfWork<NotaFiscal> unitOfWork)
            :base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<FiltroDashboardIndicadores> GetDashboardIndicadoresFiltradosAsync(int ano, int? mes = null, bool trimestral = false)
        {
            return _unitOfWork.NotaFiscalRepository.GetDashboardIndicadoresFiltradosAsync(ano, mes, trimestral);
        }

        public Task<FiltroDashboardIndicadores> GetDashboardIndicadoresAsync()
        {
            return _unitOfWork.NotaFiscalRepository.GetDashboardIndicadoresAsync();
        }
    }
}
