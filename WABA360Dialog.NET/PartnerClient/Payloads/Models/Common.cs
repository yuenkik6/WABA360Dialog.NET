using Newtonsoft.Json;

namespace WABA360Dialog.PartnerClient.Payloads.Models
{
    public class MetaInfo
    {
        [JsonProperty("business_vertical")]
        public string BusinessVertical { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("about")]
        public string About { get; set; }

        [JsonProperty("business_description")]
        public string BusinessDescription { get; set; }

        [JsonProperty("use_case")]
        public string UseCase { get; set; }
    }
}