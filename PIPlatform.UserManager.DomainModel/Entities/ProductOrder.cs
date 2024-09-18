namespace PIPlatform.UserManager.DomainModel.Entities
{
    public class ProductOrder : BaseEntity<int>
    {
        public int ProductId { get; set; }        
        public int OrderId { get; set; }
        public int Number { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
