using Newtonsoft.Json;
using WABA360Dialog.PartnerClient.Payloads.Enums;

namespace WABA360Dialog.PartnerClient.Payloads.Models
{
    public class SetupInfo
    {
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("phone_name")]
        public string PhoneName { get; set; }

        [JsonProperty("was_in_use")]
        public bool WasInUse { get; set; }

        [JsonProperty("ivr")]
        public bool Ivr { get; set; }

        [JsonProperty("verification_method")]
        public VerificationMethod VerificationMethod { get; set; }

        [JsonProperty("certificate")]
        public string Certificate { get; set; }

        [JsonProperty("new_name_status")]
        public string NewNameStatus { get; set; }

        [JsonProperty("default_language")]
        public string DefaultLanguage { get; set; }

        [JsonProperty("has_integration_layer")]
        public bool HasIntegrationLayer { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("configuration_type")]
        public string ConfigurationType { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("shards_number")]
        public int ShardsNumber { get; set; }
    }
}