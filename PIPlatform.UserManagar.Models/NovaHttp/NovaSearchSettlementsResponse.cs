namespace PIPlatform.UserManagar.Models.NovaHttp
{
    public class NovaSearchSettlementsResponse
    {
        public string TotalCount { get; set; }
        public List<NovaAddressesResponse> Addresses { get; set; }
        public string Warehouses { get; set; }
        public string MainDescription { get; set; }
        public string Area { get; set; }
        public string Region { get; set; }
        public string SettlementTypeCode { get; set; }
        public string Ref { get; set; }
        public string DeliveryCity { get; set; }
    }
}
