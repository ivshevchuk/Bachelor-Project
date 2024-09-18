using PIPlatform.UserManagar.Models;

namespace PIPlatform.UserManager.BL.Interfaces
{
    public interface ISupplyService
    {
        public Task<bool> DeleteById(int id);
        public Task<SupplyModel> Add(CreateSupplyModel supplyModel);
        public Task<IEnumerable<SupplyModel>> Search(DateTime dateTime);
        public Task<IEnumerable<SupplyModel>> GetAll();
    }
}
