using PIPlatform.UserManagar.Models;

namespace PIPlatform.UserManager.BL.Interfaces
{
    public interface INovaUserService
    {
        Task<NovaUserModel> Add(string token);

        Task<NovaUserModel> Get();
    }
}
