using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models
{
    public class ClientApiMeta
    {
        [JsonProperty("api_status")]
        public string ApiStatus { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
        
        [JsonProperty("success")]
        public bool? Success { get; set; }

        [JsonProperty("http_code")]
        public int? HttpCode { get; set; }

        [JsonProperty("developer_message")]
        public string DeveloperMessage { get; set; }
    }
}