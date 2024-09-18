using PIPlatform.UserManagar.Models.ProductOrderModels;

namespace PIPlatform.UserManagar.Models
{
    public class UpdateOrderModel
    {
        public int Id { get; set; }
        public string TrackNumber { get; set; }
        public string Post { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }
        public int CustomerId { get; set; }

        public IEnumerable<UpdateProductOrderModel> ProductOrders { get; set; }
    }
}