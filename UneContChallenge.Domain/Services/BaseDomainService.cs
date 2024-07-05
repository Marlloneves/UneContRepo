using UneContChallenge.Domain.Interfaces.Repositories;
using UneContChallenge.Domain.Interfaces.Services;

namespace UneContChallenge.Domain.Services
{
    public class BaseDomainService<TEntity> : IBaseDomainService<TEntity>
        where TEntity : class
    {
        private readonly IUnitOfWork<TEntity> _unitOfWork;

        public BaseDomainService(IUnitOfWork<TEntity> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            var data = await _unitOfWork.BaseRepository.CreateAsync(entity);
            return data;
        }

        public virtual async Task DeleteAsync(int id)
        {
            await _unitOfWork.BaseRepository.DeleteAsync(id);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public virtual Task<List<TEntity>> GetAllAsync()
        {
            return _unitOfWork.BaseRepository.GetAllAsync();
        }

        public virtual Task<TEntity> GetByIdAsync(int id)
        {
            return _unitOfWork.BaseRepository.GetByIdAsync(id);
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var data = await _unitOfWork.BaseRepository.UpdateAsync(entity);
            return data;
        }
    }
}
