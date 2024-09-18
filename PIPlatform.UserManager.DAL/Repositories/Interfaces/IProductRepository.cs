using PIPlatform.UserManager.DomainModel.Entities;

namespace PIPlatform.UserManager.DAL.Repositories.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product, int>
    {
        public Task<IEnumerable<Product>> Search(string name);
        public Task<IEnumerable<Product>> Search(int id);
    }
}
