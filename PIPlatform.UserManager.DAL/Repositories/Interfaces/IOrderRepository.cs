using PIPlatform.UserManager.DomainModel.Entities;

namespace PIPlatform.UserManager.DAL.Repositories.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order, int>
    {
        Task<IEnumerable<Order>> Search(DateTime dateTime);
        Task<IEnumerable<Order>> SearchByTrack(string track);
        Task<Order> GetByIdWithProductOrders(int id);
        Task<IEnumerable<Order>> GetAllWithProductsOrders();
    }
}
