using Newtonsoft.Json;

namespace WABA360Dialog.PartnerClient.Payloads.Models
{
    public class Client
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("contact_info")]
        public ClientContactInfo ContactInfo { get; set; }
    }
}