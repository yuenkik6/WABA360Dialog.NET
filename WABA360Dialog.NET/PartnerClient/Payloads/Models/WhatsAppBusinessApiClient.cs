using Newtonsoft.Json;
using WABA360Dialog.PartnerClient.Payloads.Enums;

namespace WABA360Dialog.PartnerClient.Payloads.Models
{
    public class WhatsAppBusinessApiClient
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public ClientStatus Status { get; set; }

        [JsonProperty("organisation")]
        public string Organisation { get; set; }

        [JsonProperty("meta_info")]
        public MetaInfo MetaInfo { get; set; }

        [JsonProperty("contact_info")]
        public ClientContactInfo ContactInfo { get; set; }

        [JsonProperty("contact_user")]
        public ContactUser ContactUser { get; set; }

        [JsonProperty("partner_payload")]
        public string PartnerPayload { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("created_by")]
        public CreatedBy CreatedBy { get; set; }

        [JsonProperty("modified_at")]
        public string ModifiedAt { get; set; }

        [JsonProperty("modified_by")]
        public ModifiedBy ModifiedBy { get; set; }
    }
}