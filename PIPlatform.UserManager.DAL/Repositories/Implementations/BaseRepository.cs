using PIPlatform.UserManager.DAL.Repositories.Interfaces;
using PIPlatform.UserManager.DomainModel;

namespace PIPlatform.UserManager.DAL.Repositories.Implementations
{
    public abstract class BaseRepository<T, K> : IBaseRepository<T, K> where T : BaseEntity<K>
    {
        protected readonly UserManagerContext _userManagerContext;

        protected BaseRepository(UserManagerContext userManagerContext)
        {
            _userManagerContext = userManagerContext;
        }

        public async Task<T> Create(T entity)
        {
            var result = await _userManagerContext.Set<T>().AddAsync(entity);
            return result.Entity;
            
        }

        public async Task<bool> Delete(K id)
        {
            var result = await _userManagerContext.Set<T>().FindAsync(id);
            if (result != null)
            {
                _userManagerContext.Set<T>().Remove(result);
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var result = _userManagerContext.Set<T>().ToList();
            return await Task.FromResult(result);
        }

        public async Task<T> Read(K id)
        {
            var result = await _userManagerContext.Set<T>().FindAsync(id);
            return result;

        }

        public async Task<bool> Update(T entity)
        {
            var result = await _userManagerContext.Set<T>().FindAsync(entity.Id);
            if (result != null)
            {
                _userManagerContext.Entry(result).CurrentValues.SetValues(entity);
                return true;
            }

            return false;
        }
    }
}
