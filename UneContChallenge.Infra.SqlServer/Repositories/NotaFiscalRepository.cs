using UneContChallenge.Domain.Entities;
using UneContChallenge.Domain.Interfaces.Repositories;
using UneContChallenge.Infra.Contexts;

namespace UneContChallenge.Infra.Repositories
{
    public class NotaFiscalRepository : BaseRepository<NotaFiscal>, INotaFiscalRepository
    {
        private readonly DataContexts _dataContexts;

        public NotaFiscalRepository(DataContexts dataContexts) : base(dataContexts)
        {
            _dataContexts = dataContexts;
        }
    }
}
