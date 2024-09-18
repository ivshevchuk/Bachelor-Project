namespace PIPlatform.UserManagar.Models.NovaHttp
{
    public class NovaBaseRequest
    {
        public string apiKey { get; set; }
        public string modelName { get; set; }
        public string calledMethod { get; set; }
        public MethodProperties methodProperties { get; set; } = new MethodProperties();

        public NovaBaseRequest(string apiKey, string modelName, string calledMethod, MethodProperties methodProperties)
        {
            this.apiKey = apiKey;
            this.modelName = modelName;
            this.calledMethod = calledMethod;
            this.methodProperties = methodProperties;
        }
    }
}
