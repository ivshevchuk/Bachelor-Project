using AutoMapper;
using PIPlatform.UserManagar.Models;
using PIPlatform.UserManagar.Models.OrderModels;
using PIPlatform.UserManager.BL.Interfaces;
using PIPlatform.UserManager.DAL.Repositories.Interfaces;
using PIPlatform.UserManager.DomainModel.Entities;

namespace PIPlatform.UserManager.BL.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductOrderRepository _productOrderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IUnitOfWork unitOfWork, IMapper mapper, IProductOrderRepository productOrderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productOrderRepository = productOrderRepository;
            _productRepository = productRepository;
        }

        public async Task<OrderModel> Add(CreateOrderModel orderModel)
        {
            Order order = await _orderRepository.Create(_mapper.Map<Order>(orderModel));

            var productOrders = order.ProductOrders;
            foreach (var productOrder in productOrders)
            {
                var product = await _productRepository.Read(productOrder.ProductId);
                product.Number -= productOrder.Number;

                if(product.Number < 0)
                {
                    throw new Exception("No enough products");
                }
                await _productRepository.Update(product);
                
            }
            await _unitOfWork.SaveAsync();

            var orderWithProduct = await _orderRepository.GetByIdWithProductOrders(order.Id);

            orderWithProduct.Price = orderWithProduct.ProductOrders.Select(i => i.Product.Price * i.Number).Sum();

            await _orderRepository.Update(orderWithProduct);

            await _unitOfWork.SaveAsync();

            OrderModel result = _mapper.Map<OrderModel>(order);
            return result;
        }

        public async Task<bool> DeleteById(int id)
        {
            var previousOrder = await _orderRepository.GetByIdWithProductOrders(id);
            var productOrders = previousOrder.ProductOrders;

            foreach (var productOrder in productOrders)
            {
                var product = await _productRepository.Read(productOrder.ProductId);
                product.Number += productOrder.Number;
                await _productRepository.Update(product);
            }

            bool result = await _orderRepository.Delete(id);
            await _unitOfWork.SaveAsync();
            return result;
        }

        public async Task<bool> Update(UpdateOrderModel orderModel)
        {
            var previousOrder = await _orderRepository.GetByIdWithProductOrders(orderModel.Id);
            var productOrders = previousOrder.ProductOrders;

            foreach (var productOrder in productOrders)
            {
                var product = await _productRepository.Read(productOrder.ProductId);
                product.Number += productOrder.Number;
                await _productRepository.Update(product);
                await _productOrderRepository.Delete(productOrder.Id);
            }

            foreach (var productOrder in orderModel.ProductOrders)
            {
                var product = await _productRepository.Read(productOrder.ProductId);
                product.Number -= productOrder.Number;

                if (product.Number < 0)
                {
                    throw new Exception("No enough products");
                }
                await _productRepository.Update(product);
                await _productOrderRepository.Create(_mapper.Map<ProductOrder>(productOrder));
            }

            var orderWithProduct = await _orderRepository.GetByIdWithProductOrders(orderModel.Id);
            var order = _mapper.Map<Order>(orderModel);

            order.Price = orderWithProduct.ProductOrders.Select(i => i.Product.Price * i.Number).Sum();

            var result = await _orderRepository.Update(order);

            await _unitOfWork.SaveAsync();

            return result;
        }

        public async Task<IEnumerable<OrderModel>> GetAll()
        {
            IEnumerable<Order> orders = await _orderRepository.GetAllWithProductsOrders();
            await _unitOfWork.SaveAsync();
            IEnumerable<OrderModel> result = _mapper.Map<IEnumerable<OrderModel>>(orders);
            return result;
        }

        public async Task<IEnumerable<OrderModel>> SearchByDate(DateTime date)
        {
            IEnumerable<Order> orders = await _orderRepository.Search(date);
            await _unitOfWork.SaveAsync();
            IEnumerable<OrderModel> result = _mapper.Map<IEnumerable<OrderModel>>(orders);
            return result;
        }

        public async Task<IEnumerable<OrderModel>> SearchByTrackNumber(string trackNumber)
        {
            IEnumerable<Order> orders = await _orderRepository.SearchByTrack(trackNumber);
            await _unitOfWork.SaveAsync();
            IEnumerable<OrderModel> result = _mapper.Map<IEnumerable<OrderModel>>(orders);
            return result;
        }
    }
}
