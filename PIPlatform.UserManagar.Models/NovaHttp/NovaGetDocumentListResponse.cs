﻿namespace PIPlatform.UserManagar.Models.NovaHttp
{
    public class NovaGetDocumentListResponse
    {
        public string Ref { get; set; }
        public string RecipientDateTime { get; set; }
        public string EWDateCreated { get; set; }
        public string Weight { get; set; }
        public string Cost { get; set; }
        public string CitySender { get; set; }
        public string CityRecipient { get; set; }
        public string SenderAddress { get; set; }
        public string RecipientAddress { get; set; }
        public string CostOnSite { get; set; }
        public string AfterpaymentOnGoodsCost { get; set; }
        public string PackingNumber { get; set; }
        public string StateId { get; set; }
        public string StateName { get; set; }
    }
}
