using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PIPlatform.UserManagar.Models;
using PIPlatform.UserManagar.Models.OrderModels;
using PIPlatform.UserManager.BL.Interfaces;

namespace PIPlatform.UserManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("[action]")]
        public async Task<OrderModel> Add(CreateOrderModel orderModel)
        {
            return await _orderService.Add(orderModel);
        }

        [HttpDelete("[action]")]
        public async Task<bool> DeleteById(int id)
        {
            return await _orderService.DeleteById(id);
        }

        [HttpPut("[action]")]
        public async Task<bool> Update(UpdateOrderModel orderModel)
        {
            return await _orderService.Update(orderModel);
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<OrderModel>> GetAll()
        {
            return await _orderService.GetAll();
        }

        [HttpGet("[action]/{date}")]
        public async Task<IEnumerable<OrderModel>> SearchByDate(DateTime date)
        {
            return await _orderService.SearchByDate(date);
        }

        [HttpGet("[action]/{trackNumber}")]
        public async Task<IEnumerable<OrderModel>> SearchByTrackNumber(string trackNumber)
        {
            return await _orderService.SearchByTrackNumber(trackNumber);
        }
    }
}
