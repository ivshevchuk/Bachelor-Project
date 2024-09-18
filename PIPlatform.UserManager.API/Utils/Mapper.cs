using AutoMapper;
using PIPlatform.UserManagar.Models;
using PIPlatform.UserManagar.Models.CustomerModels;
using PIPlatform.UserManagar.Models.OrderModels;
using PIPlatform.UserManagar.Models.ProductOrderModels;
using PIPlatform.UserManager.DomainModel.Entities;

namespace PIPlatform.UserManager.API.Utils
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Customer, CustomerNameAndPhoneModel>();
            CreateMap<CreateCustomerModel, Customer>();
            CreateMap<UpdateCustomerModel, Customer>();
            CreateMap<Customer, CustomerModel>();

            CreateMap<CreateOrderModel, Order>();
            CreateMap<UpdateOrderModel, Order>();

            CreateMap<CreateProductOrderModel, ProductOrder>();
            CreateMap<UpdateProductOrderModel, ProductOrder>();

            CreateMap<CreateProductModel, Product>();

            CreateMap<CreateSupplyModel, Supply>();

            CreateMap<Order, OrderModel>().ReverseMap();
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<ProductOrder, ProductOrderModel>().ReverseMap();
            CreateMap<Supply, SupplyModel>().ReverseMap();
            CreateMap<NovaUser, NovaUserModel>().ReverseMap();
        }
    }
}
