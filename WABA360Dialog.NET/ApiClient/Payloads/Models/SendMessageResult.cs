using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models
{
    public class SendMessageResult
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}