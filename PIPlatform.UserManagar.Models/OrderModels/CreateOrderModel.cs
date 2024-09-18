using PIPlatform.UserManagar.Models.ProductOrderModels;

namespace PIPlatform.UserManagar.Models
{
    public class CreateOrderModel
    {
        public string TrackNumber { get; set; }
        public string Post { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }
        public int CustomerId { get; set; }

        public IEnumerable<CreateProductOrderModel> ProductOrders { get; set; }
    }
}