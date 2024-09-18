using Microsoft.EntityFrameworkCore;
using PIPlatform.UserManager.DAL.Repositories.Interfaces;
using PIPlatform.UserManager.DomainModel.Entities;

namespace PIPlatform.UserManager.DAL.Repositories.Implementations
{
    public class ProductRepository : BaseRepository<Product, int>, IProductRepository
    {
        public ProductRepository(UserManagerContext userManagerContext) : base(userManagerContext)
        {
        }

        public async Task<IEnumerable<Product>> Search(string name)
        {
            IEnumerable<Product> result = await _userManagerContext.Products.Where(p => p.Name == name).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Product>> Search(int id)
        {
            IEnumerable<Product> result = await _userManagerContext.Products.Where(p => p.Id == id).ToListAsync();
            return result;
        }
    }
}
