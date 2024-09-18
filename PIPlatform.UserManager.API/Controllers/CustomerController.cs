using Microsoft.AspNetCore.Mvc;
using PIPlatform.UserManagar.Models;
using PIPlatform.UserManagar.Models.CustomerModels;
using PIPlatform.UserManager.BL.Interfaces;

namespace PIPlatform.UserManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("[action]")]
        public async Task<CustomerModel> Add(CreateCustomerModel customerModel)
        {
            return await _customerService.Add(customerModel);
        }

        [HttpGet("[action]/{key}")]
        public async Task<IEnumerable<CustomerNameAndPhoneModel>> Search(string key)
        {
            return await _customerService.Search(key);
        }

        [HttpGet("[action]/{id}")]
        public async Task<CustomerModel> GetById(int id)
        {
            return await _customerService.GetById(id);
        }

        [HttpPut("[action]")]
        public async Task<bool> Update(UpdateCustomerModel customerModel)
        {
            return await _customerService.Update(customerModel);
        }

        [HttpDelete("[action]")]
        public async Task<bool> DeleteById(int id)
        {
            return await _customerService.DeleteById(id);
        }
    }
}
