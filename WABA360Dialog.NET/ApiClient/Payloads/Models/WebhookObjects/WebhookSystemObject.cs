using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.WebhookObjects
{
    public class WebhookSystemObject
    {
        [JsonProperty("body")]
        public string Body { get; set; }
    }
}