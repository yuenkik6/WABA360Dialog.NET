using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models
{
    public class ClientApiMeta
    {
        [JsonProperty("api_status")]
        public string ApiStatus { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}