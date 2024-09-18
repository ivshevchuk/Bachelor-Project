namespace PIPlatform.UserManagar.Models.NovaHttp
{
    public class NovaGetStatusDocumentsResponse
    {
        public bool PossibilityChangeEW { get; set; }
        public string DocumentCost { get; set; }
        public string RecipientFullName { get; set; }
        public string ScheduledDeliveryDate { get; set; }
        public string CityRecipient { get; set; }
        public string WarehouseRecipientNumber { get; set; }
        public string PhoneRecipient { get; set; }
        public string Status { get; set; }
        public string DatePayedKeeping { get; set; }
        public string AnnouncedPrice { get; set; }
        public string OwnerDocumentNumber { get; set; }
    }
}
