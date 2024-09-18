namespace PIPlatform.UserManagar.Models.NovaHttp
{
    public class NovaUpdateRequest : MethodProperties
    {
        public string Ref { get; set; }
        public string PayerType { get; set; }
        public string PaymentMethod { get; set; }
        public string DateTime { get; set; }
        public string CargoType { get; set; }
        public string Weight { get; set; }
        public string ServiceType { get; set; }
        public string SeatsAmount { get; set; }
        public string Description { get; set; }
        public string Cost { get; set; }
        public string CitySender { get; set; }
        public string Sender { get; set; }
        public string SenderAddress { get; set; }
        public string ContactSender { get; set; }
        public string SendersPhone { get; set; }
        public string CityRecipient { get; set; }
        public string Recipient { get; set; }
        public string RecipientAddress { get; set; }
        public string ContactRecipient { get; set; }
        public string RecipientsPhone { get; set; }

        public NovaUpdateRequest()
        {
        }

        public NovaUpdateRequest(string refer, string payerType, string paymentMethod, string dateTime, string cargoType, 
            string weight, string serviceType, string seatsAmount, string description, string cost, string citySender, 
            string sender, string senderAddress, string contactSender, string sendersPhone, string cityRecipient, 
            string recipient, string recipientAddress, string contactRecipient, string recipientsPhone)
        {
            Ref = refer;
            PayerType = payerType;
            PaymentMethod = paymentMethod;
            DateTime = dateTime;
            CargoType = cargoType;
            Weight = weight;
            ServiceType = serviceType;
            SeatsAmount = seatsAmount;
            Description = description;
            Cost = cost;
            CitySender = citySender;
            Sender = sender;
            SenderAddress = senderAddress;
            ContactSender = contactSender;
            SendersPhone = sendersPhone;
            CityRecipient = cityRecipient;
            Recipient = recipient;
            RecipientAddress = recipientAddress;
            ContactRecipient = contactRecipient;
            RecipientsPhone = recipientsPhone;
        }
    }
}
