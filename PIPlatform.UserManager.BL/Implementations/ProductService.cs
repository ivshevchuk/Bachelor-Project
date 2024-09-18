using AutoMapper;
using PIPlatform.UserManagar.Models;
using PIPlatform.UserManager.BL.Interfaces;
using PIPlatform.UserManager.DAL.Repositories.Interfaces;
using PIPlatform.UserManager.DomainModel.Entities;

namespace PIPlatform.UserManager.BL.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductModel> Add(CreateProductModel productModel)
        {
            Product products = await _productRepository.Create(_mapper.Map<Product>(productModel));
            await _unitOfWork.SaveAsync();
            ProductModel result = _mapper.Map<ProductModel>(products);
            return result;
        }

        public async Task<bool> DeleteById(int id)
        {
            bool result = await _productRepository.Delete(id);
            await _unitOfWork.SaveAsync();
            return result;
        }

        public async Task<bool> Update(ProductModel productModel)
        {
            bool result = await _productRepository.Update(_mapper.Map<Product>(productModel));
            await _unitOfWork.SaveAsync();
            return result;
        }

        public async Task<IEnumerable<ProductModel>> Search(string key)
        {
            IEnumerable<Product> products = await GetProductsByKey(key);

            IEnumerable<ProductModel> allProductsResult = _mapper.Map<IEnumerable<ProductModel>>(products);
            return allProductsResult;
        }
        
        private async Task<IEnumerable<Product>> GetProductsByKey(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return await _productRepository.GetAll();
            }

            if (Int32.TryParse(key, out int result))
            {
                return await _productRepository.Search(result);
            }

            return await _productRepository.Search(key);
        }
    }
}
