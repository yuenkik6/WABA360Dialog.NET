using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.WebhookObjects
{
    public class ProfileObject
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}