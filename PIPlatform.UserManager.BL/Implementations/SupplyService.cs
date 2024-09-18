using AutoMapper;
using PIPlatform.UserManagar.Models;
using PIPlatform.UserManager.BL.Interfaces;
using PIPlatform.UserManager.DAL.Repositories.Interfaces;
using PIPlatform.UserManager.DomainModel.Entities;

namespace PIPlatform.UserManager.BL.Implementations
{
    public class SupplyService : ISupplyService
    {
        private readonly ISupplyRepository _supplyRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SupplyService(ISupplyRepository supplyRepository, IUnitOfWork unitOfWork, IMapper mapper, IProductRepository productRepository)
        {
            _supplyRepository = supplyRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<bool> DeleteById(int id)
        {
            var supply = await _supplyRepository.Read(id);
            var product = await _productRepository.Read(supply.ProductId);

            product.Number += supply.Number;

            if (product.Number < 0)
            {
                throw new Exception("Impossible to delete supply, products was already sold");
            }

            await _productRepository.Update(product);
            bool result = await _supplyRepository.Delete(id);

            await _unitOfWork.SaveAsync();
            return result;
        }

        public async Task<SupplyModel> Add(CreateSupplyModel supplyModel)
        {
            Supply supplies = await _supplyRepository.Create(_mapper.Map<Supply>(supplyModel));

            var product = await _productRepository.Read(supplyModel.ProductId);
            product.Number += supplyModel.Number;

            await _productRepository.Update(product);
            await _unitOfWork.SaveAsync();

            SupplyModel result = _mapper.Map<SupplyModel>(supplies);
            return result;
        }
        
        public async Task<IEnumerable<SupplyModel>> Search(DateTime dateTime)
        {
            IEnumerable<Supply> supplies = await _supplyRepository.Search(dateTime);
            await _unitOfWork.SaveAsync();
            IEnumerable<SupplyModel> result = _mapper.Map<IEnumerable<SupplyModel>>(supplies);
            return result;
        }

        public async Task<IEnumerable<SupplyModel>> GetAll()
        {
            IEnumerable<Supply> supplies = await _supplyRepository.GetAll();
            await _unitOfWork.SaveAsync();
            IEnumerable<SupplyModel> result = _mapper.Map<IEnumerable<SupplyModel>>(supplies);
            return result;
        }
    }
}
