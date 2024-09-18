namespace PIPlatform.UserManager.DomainModel.Entities
{
    public class Order : BaseEntity<int>
    {
        public decimal Price { get; set; }
        public string TrackNumber { get; set; }
        public string Post { get; set; }
        public DateTime Date { get; set; }
        public OrderStatus Status { get; set; }
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
        public IEnumerable<ProductOrder> ProductOrders { get; set; }
    }
}
