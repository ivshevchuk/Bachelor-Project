namespace PIPlatform.UserManagar.Models.NovaHttp
{
    public class NovaGetDocumentListRequest : MethodProperties
    {
        public string DateTimeFrom { get; set; }
        public string DateTimeTo { get; set; }
        public string Page { get; set; }
        public string GetFullList { get; set; }
        public string DateTime { get; set; }

        public NovaGetDocumentListRequest(string dateTimeFrom, string dateTimeTo, string page, string getFullList, string dateTime)
        {
            DateTimeFrom = dateTimeFrom;
            DateTimeTo = dateTimeTo;
            Page = page;
            GetFullList = getFullList;
            DateTime = dateTime;
        }
    }
}
