namespace PIPlatform.UserManager.DomainModel.Entities
{
    public class Product : BaseEntity<int>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Number { get; set; }

        public IEnumerable<ProductOrder> ProductOrders { get; set; }
    }
}
