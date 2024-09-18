using PIPlatform.UserManager.DomainModel;

namespace PIPlatform.UserManagar.Models.CustomerModels
{
    public class CreateCustomerModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public CustomerStatus Status { get; set; }
    }
}
