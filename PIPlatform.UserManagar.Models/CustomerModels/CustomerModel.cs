using PIPlatform.UserManagar.Models.OrderModels;
using PIPlatform.UserManager.DomainModel;

namespace PIPlatform.UserManagar.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public CustomerStatus Status { get; set; }

        public IEnumerable<OrderModel> Orders { get; set; }
    }
}
