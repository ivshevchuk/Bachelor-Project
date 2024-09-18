using PIPlatform.UserManager.DAL.Repositories.Interfaces;
using PIPlatform.UserManager.DomainModel.Entities;

namespace PIPlatform.UserManager.DAL.Repositories.Implementations
{
    public class NovaUserRepository : BaseRepository<NovaUser, int>, INovaUserRepository
    {
        public NovaUserRepository(UserManagerContext userManagerContext) : base(userManagerContext)
        {
        }
    }
}
