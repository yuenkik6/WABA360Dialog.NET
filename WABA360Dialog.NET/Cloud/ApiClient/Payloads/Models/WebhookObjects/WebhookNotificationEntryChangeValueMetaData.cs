using Newtonsoft.Json;

namespace WABA360Dialog.Cloud.ApiClient.Payloads.Models.WebhookObjects
{
    public class WebhookNotificationEntryChangeValueMetaData
    {
        [JsonProperty("display_phone_number")]
        public string DisplayPhoneNumber { get; set; }

        [JsonProperty("phone_number_id")]
        public string PhoneNumberId { get; set; }
    }
}