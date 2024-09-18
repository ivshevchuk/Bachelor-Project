namespace PIPlatform.UserManagar.Models
{
    public class CreateSupplyModel
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
    }
}
