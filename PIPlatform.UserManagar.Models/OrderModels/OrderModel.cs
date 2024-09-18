using PIPlatform.UserManagar.Models.ProductOrderModels;

namespace PIPlatform.UserManagar.Models.OrderModels
{
    public class OrderModel
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string TrackNumber { get; set; }
        public string Post { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }
        public int CustomerId { get; set; }

        public IEnumerable<ProductOrderModel> ProductOrders { get; set; }
    }
}
