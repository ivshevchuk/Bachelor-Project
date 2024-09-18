namespace PIPlatform.UserManagar.Models.NovaHttp
{
    public class NovaGetWarehousesRequest : MethodProperties
    {
        public string CityRef { get; set; }

        public NovaGetWarehousesRequest( string cityRef)
        {
            CityRef = cityRef;
        }
    }
}
