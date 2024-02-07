using Newtonsoft.Json;

namespace WABA360Dialog.Cloud.ApiClient.Payloads.Models.WebhookObjects
{
    public class WebhookNotificationEntryChange
    {
        [JsonProperty("field")]
        public string Field { get; set; }

        [JsonProperty("value")]
        public WebhookNotificationEntryChangeValue Value { get; set; }
    }
}