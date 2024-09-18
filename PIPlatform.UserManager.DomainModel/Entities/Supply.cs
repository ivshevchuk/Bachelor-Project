namespace PIPlatform.UserManager.DomainModel.Entities
{
    public class Supply : BaseEntity<int>
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }

        public Product Product { get; set; }
    }
}
