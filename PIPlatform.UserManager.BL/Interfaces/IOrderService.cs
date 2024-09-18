using PIPlatform.UserManagar.Models;
using PIPlatform.UserManagar.Models.OrderModels;

namespace PIPlatform.UserManager.BL.Interfaces
{
    public interface IOrderService
    {
        Task<OrderModel> Add(CreateOrderModel orderModel);
        Task<bool> DeleteById(int id);
        Task<bool> Update(UpdateOrderModel orderModel);
        Task<IEnumerable<OrderModel>> GetAll();
        Task<IEnumerable<OrderModel>> SearchByDate(DateTime date);
        Task<IEnumerable<OrderModel>> SearchByTrackNumber(string trackNumber);
    }
}
