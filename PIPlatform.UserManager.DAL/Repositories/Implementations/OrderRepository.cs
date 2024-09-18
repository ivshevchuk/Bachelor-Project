using Microsoft.EntityFrameworkCore;
using PIPlatform.UserManager.DAL.Repositories.Interfaces;
using PIPlatform.UserManager.DomainModel.Entities;

namespace PIPlatform.UserManager.DAL.Repositories.Implementations
{
    public class OrderRepository : BaseRepository<Order, int>, IOrderRepository
    {
        public OrderRepository(UserManagerContext userManagerContext) : base(userManagerContext)
        {
        }

        public async Task<IEnumerable<Order>> Search(DateTime dateTime)
        {
            IEnumerable<Order> result = await _userManagerContext.Orders.Include(i => i.ProductOrders).ThenInclude(i => i.Product).Where(s => s.Date.Date == dateTime.Date).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Order>> SearchByTrack(string track)
        {
            IEnumerable<Order> result = await _userManagerContext.Orders.Include(i => i.ProductOrders).ThenInclude(i => i.Product).Where(s => s.TrackNumber == track).ToListAsync();
            return result;
        }

        public async Task<Order> GetByIdWithProductOrders(int id)
        {
            var result = await _userManagerContext.Orders
                .Include(i => i.ProductOrders).ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(i => i.Id == id);

            return result;
        }

        public async Task<IEnumerable<Order>> GetAllWithProductsOrders()
        {
            IEnumerable<Order> result = await _userManagerContext.Orders.Include(i => i.ProductOrders).ThenInclude(i => i.Product).ToListAsync();
            return result;
        }
    }
}
