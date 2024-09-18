using PIPlatform.UserManagar.Models;
using PIPlatform.UserManagar.Models.CustomerModels;

namespace PIPlatform.UserManager.BL.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerNameAndPhoneModel>> Search(string key);
        Task<CustomerModel> Add(CreateCustomerModel customerModel);
        Task<CustomerModel> GetById(int id);
        Task<bool> Update(UpdateCustomerModel customerModel);
        Task<bool> DeleteById(int id);
    }
}
