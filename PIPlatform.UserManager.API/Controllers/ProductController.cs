using Microsoft.AspNetCore.Mvc;
using PIPlatform.UserManagar.Models;
using PIPlatform.UserManager.BL.Interfaces;

namespace PIPlatform.UserManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("[action]")]
        public async Task<ProductModel> Add(CreateProductModel productModel)
        {
            return await _productService.Add(productModel);
        }

        [HttpDelete("[action]")]
        public async Task<bool> DeleteById(int id)
        {
            return await _productService.DeleteById(id);
        }

        [HttpPut("[action]")]
        public async Task<bool> Update(ProductModel productModel)
        {
            return await _productService.Update(productModel);
        }

        [HttpGet("[action]/{key}")]
        public async Task<IEnumerable<ProductModel>> Search(string key)
        {
            return await _productService.Search(key);
        }
    }
}
