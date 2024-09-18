using PIPlatform.UserManagar.Models;

namespace PIPlatform.UserManager.BL.Interfaces
{
    public interface IProductService
    {
        public Task<ProductModel> Add(CreateProductModel productModel);
        public Task<bool> DeleteById(int id);
        public Task<bool> Update(ProductModel productModel);
        public Task<IEnumerable<ProductModel>> Search(string key);
    }
}
