using Microsoft.EntityFrameworkCore;
using UneContChallenge.Domain.Interfaces.Repositories;
using UneContChallenge.Infra.Contexts;

namespace UneContChallenge.Infra.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        private readonly DataContexts _dataContexts;

        public BaseRepository(DataContexts dataContexts)
            :base()
        {
            _dataContexts = dataContexts;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            _dataContexts.Entry(entity).State = EntityState.Added;
            await _dataContexts.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            TEntity? entity = await _dataContexts.Set<TEntity>().FindAsync(id);

            if (entity is not null)
                _dataContexts.Remove(entity);

            await _dataContexts.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dataContexts?.Dispose();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dataContexts.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            TEntity? entity = await _dataContexts.Set<TEntity>().FindAsync().AsTask();

            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _dataContexts.Set<TEntity>().Update(entity);
            await _dataContexts.SaveChangesAsync();
            return entity;
        }
    }
}
