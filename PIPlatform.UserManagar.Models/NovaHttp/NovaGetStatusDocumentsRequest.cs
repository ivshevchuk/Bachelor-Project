namespace PIPlatform.UserManagar.Models.NovaHttp
{
    public class NovaGetStatusDocumentsRequest : MethodProperties
    {
        public List<NovaDocumentsRequest> Documents { get; set; }

        public NovaGetStatusDocumentsRequest(List<NovaDocumentsRequest> documents)
        {
            Documents = documents;
        }
    }
}
