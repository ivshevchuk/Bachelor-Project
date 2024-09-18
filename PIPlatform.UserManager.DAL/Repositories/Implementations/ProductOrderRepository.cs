using PIPlatform.UserManager.DAL.Repositories.Interfaces;
using PIPlatform.UserManager.DomainModel.Entities;

namespace PIPlatform.UserManager.DAL.Repositories.Implementations
{
    public class ProductOrderRepository : BaseRepository<ProductOrder, int>, IProductOrderRepository
    {
        public ProductOrderRepository(UserManagerContext userManagerContext) : base(userManagerContext)
        {
        }
    }
}
