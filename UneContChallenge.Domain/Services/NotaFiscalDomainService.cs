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
    }
}
