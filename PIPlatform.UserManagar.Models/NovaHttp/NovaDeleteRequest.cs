namespace PIPlatform.UserManagar.Models.NovaHttp
{
    public class NovaDeleteRequest : MethodProperties
    {
        public string DocumentRefs { get; set; }

        public NovaDeleteRequest(string documentRefs)
        {
            DocumentRefs = documentRefs;
        }
    }
}
