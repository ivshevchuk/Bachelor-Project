namespace PIPlatform.UserManagar.Models.NovaHttp
{
    public class NovaDocumentsRequest : MethodProperties
    {
        public string DocumentNumber { get; set; }
        public string Phone { get; set; }

        public NovaDocumentsRequest(string documentNumber, string phone)
        {
            DocumentNumber = documentNumber;
            Phone = phone;
        }
    }
}
