namespace PIPlatform.UserManager.DomainModel.Entities
{
    public class Customer : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public CustomerStatus Status { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}
 