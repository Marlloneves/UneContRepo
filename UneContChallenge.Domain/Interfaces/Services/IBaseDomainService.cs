namespace UneContChallenge.Domain.Interfaces.Services
{
    public interface IBaseDomainService<TEntity> :IDisposable 
        where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
        Task<TEntity> GetByIdAsync(int id);
        Task<List<TEntity>> GetAllAsync();
    }
}
