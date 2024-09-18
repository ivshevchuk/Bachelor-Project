using PIPlatform.UserManager.DAL.Repositories.Interfaces;

namespace PIPlatform.UserManager.DAL.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserManagerContext _userManagerContext;

        public UnitOfWork(UserManagerContext userManagerContext)
        {
            _userManagerContext = userManagerContext;
        }
        public async Task SaveAsync()
        {
            await _userManagerContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _userManagerContext.Dispose();
        }
    }
}
