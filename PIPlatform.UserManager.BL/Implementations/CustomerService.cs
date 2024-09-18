using AutoMapper;
using PIPlatform.UserManagar.Models;
using PIPlatform.UserManagar.Models.CustomerModels;
using PIPlatform.UserManager.BL.Interfaces;
using PIPlatform.UserManager.DAL.Repositories.Interfaces;
using PIPlatform.UserManager.DomainModel.Entities;

namespace PIPlatform.UserManager.BL.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CustomerModel> Add(CreateCustomerModel customerModel)
        {
            Customer customers = await _customerRepository.Create(_mapper.Map<Customer>(customerModel));
            await _unitOfWork.SaveAsync();
            CustomerModel result = _mapper.Map<CustomerModel>(customers);
            return result;
        }

        public async Task<IEnumerable<CustomerNameAndPhoneModel>> Search(string key)
        {
            if (string.IsNullOrEmpty(key)) 
            {
                IEnumerable<Customer> allCustomers = await _customerRepository.GetAll();
                IEnumerable<CustomerNameAndPhoneModel> allCustomersResult = _mapper.Map<IEnumerable<CustomerNameAndPhoneModel>>(allCustomers);
                return allCustomersResult;
            }
            string[] keys = key.Split(' ');
            IEnumerable<Customer> customers =  await _customerRepository.Search(keys);
            IEnumerable<CustomerNameAndPhoneModel>  result = _mapper.Map<IEnumerable<CustomerNameAndPhoneModel>>(customers);
            return result;
        }

        public async Task<CustomerModel> GetById(int id)
        {
            Customer customers = await _customerRepository.ReadWithOrders(id);
            CustomerModel result = _mapper.Map<CustomerModel>(customers);
            return result;
        }

        public async Task<bool> Update(UpdateCustomerModel customerModel)
        {
            bool result = await _customerRepository.Update(_mapper.Map<Customer>(customerModel));
            await _unitOfWork.SaveAsync();
            return result;
        }

        public async Task<bool> DeleteById(int id)
        {
            bool result = await _customerRepository.Delete(id);
            await _unitOfWork.SaveAsync();
            return result;
        }
    }
}
