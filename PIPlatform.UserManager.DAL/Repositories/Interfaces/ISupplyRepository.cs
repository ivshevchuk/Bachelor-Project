using PIPlatform.UserManager.DomainModel.Entities;

namespace PIPlatform.UserManager.DAL.Repositories.Interfaces
{
    public interface ISupplyRepository : IBaseRepository<Supply, int>
    {
        public Task<IEnumerable<Supply>> Search(DateTime dateTime);
    }
}
