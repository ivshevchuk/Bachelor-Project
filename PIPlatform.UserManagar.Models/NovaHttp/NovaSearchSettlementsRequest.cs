namespace PIPlatform.UserManagar.Models.NovaHttp
{
    public class NovaSearchSettlementsRequest : MethodProperties
    {
        public string CityName { get; set; }
        public string Limit { get; set; }
        public string Page { get; set; }

        public NovaSearchSettlementsRequest(string cityName, string limit, string page)
        {
            CityName = cityName;
            Limit = limit;
            Page = page;
        }
    }
}
