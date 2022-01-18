using Newtonsoft.Json;

namespace WABA360Dialog.PartnerClient.Payloads.Models
{
    public class Integration
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }
}