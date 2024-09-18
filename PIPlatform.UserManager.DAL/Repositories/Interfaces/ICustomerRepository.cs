using PIPlatform.UserManager.DomainModel.Entities;

namespace PIPlatform.UserManager.DAL.Repositories.Interfaces
{
    public interface ICustomerRepository : IBaseRepository<Customer, int>
    {
        Task<IEnumerable<Customer>> Search (string[] name);
        Task<Customer> ReadWithOrders(int id);
    }
}
