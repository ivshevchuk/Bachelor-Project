using Microsoft.EntityFrameworkCore;
using PIPlatform.UserManager.DAL.Repositories.Interfaces;
using PIPlatform.UserManager.DomainModel.Entities;

namespace PIPlatform.UserManager.DAL.Repositories.Implementations
{
    public class CustomerRepository : BaseRepository<Customer, int>, ICustomerRepository
    {
        public CustomerRepository(UserManagerContext userManagerContext) : base(userManagerContext)
        {
        }

        public async Task<IEnumerable<Customer>> Search(string[] keys)
        {
            var result = await _userManagerContext.Customers.Where(c => keys.Contains(c.Name) || keys.Contains(c.Surname) || keys.Contains(c.MiddleName) || keys.Contains(c.Phone)).ToListAsync();
            return result;
        }
        
        public async Task<Customer> ReadWithOrders(int id)
        {
            var result = await _userManagerContext.Customers.Include(c => c.Orders).ThenInclude(o => o.ProductOrders).ThenInclude(po => po.Product).FirstOrDefaultAsync(c => c.Id == id);
            return result;
        }
    }
}
