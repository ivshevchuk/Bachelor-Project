using Microsoft.EntityFrameworkCore;
using PIPlatform.UserManager.DAL.Repositories.Interfaces;
using PIPlatform.UserManager.DomainModel.Entities;

namespace PIPlatform.UserManager.DAL.Repositories.Implementations
{
    public class SupplyRepository : BaseRepository<Supply, int>, ISupplyRepository
    {
        public SupplyRepository(UserManagerContext userManagerContext) : base(userManagerContext)
        {
        }
        public async Task<IEnumerable<Supply>> Search(DateTime dateTime)
        {
            IEnumerable<Supply> result = await _userManagerContext.Supplies.Where(s => s.Date.Date==dateTime.Date).ToListAsync();
            return result;
        }
    }
}
