namespace PIPlatform.UserManagar.Models.ProductOrderModels
{
    public class ProductOrderModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Number { get; set; }

        public ProductModel Product { get; set; }
    }
}
