namespace UneContChallenge.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> : IDisposable 
        where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
    }
}
