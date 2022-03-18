using Newtonsoft.Json;

namespace WABA360Dialog.PartnerClient.Payloads.Models
{
    public class Integration
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
        
        [JsonProperty("app_id")]
        public string AppId { get; set; }
        
        [JsonProperty("state")]
        public string State { get; set; }
    }
}