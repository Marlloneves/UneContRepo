using Microsoft.EntityFrameworkCore.Storage;
using UneContChallenge.Domain.Interfaces.Repositories;
using UneContChallenge.Infra.Contexts;

namespace UneContChallenge.Infra.Repositories
{
    public class UnitOfWork<TEntity> : IUnitOfWork<TEntity>
        where TEntity : class
    {
        private readonly DataContexts _dataContexts;
        private IDbContextTransaction? _transaction;

        public UnitOfWork(DataContexts dataContexts)
        {
            _dataContexts = dataContexts;
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _dataContexts.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            await _transaction!.CommitAsync();
        }

        public async Task RollBackAsync()
        {
            await _transaction!.RollbackAsync();
        }

        public void Dispose()
        {
            _dataContexts?.Dispose();
        }

        public IBaseRepository<TEntity> BaseRepository => new BaseRepository<TEntity>(_dataContexts);

        public INotaFiscalRepository NotaFiscalRepository => new NotaFiscalRepository(_dataContexts);
    }
}
