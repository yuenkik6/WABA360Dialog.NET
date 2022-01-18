using Newtonsoft.Json;
using WABA360Dialog.PartnerClient.Payloads.Enums;

namespace WABA360Dialog.PartnerClient.Payloads.Models
{
    public class OnBehalfOfBusinessInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public BusinessInfoStatus Status { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}