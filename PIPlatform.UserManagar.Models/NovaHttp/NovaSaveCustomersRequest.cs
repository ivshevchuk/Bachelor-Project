namespace PIPlatform.UserManagar.Models.NovaHttp
{
    public class NovaSaveCustomersRequest : MethodProperties
    {
        public string CounterpartyRef { get; set; } = "20440fb8-5ae0-11ee-a60f-48df37b921db";
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Phone { get; set; }

        public NovaSaveCustomersRequest(string counterpartyRef, string firstName, string lastName, string middleName, string phone)
        {
            CounterpartyRef = counterpartyRef;
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            Phone = phone;
        }
    }
}
