namespace PIPlatform.UserManager.DomainModel.Entities
{
    public class NovaUser : BaseEntity<int>
    {
        public string Token { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string Warehouse { get; set; }
        public string Ref { get; set; }

        public string ContactRef { get; set; }
    }
}
