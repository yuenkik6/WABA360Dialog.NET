using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models
{
    public class CheckContactResult
    {
        [JsonProperty("input")]
        public string Input { get; set; }

        [JsonProperty("wa_id")]
        public string WaId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}