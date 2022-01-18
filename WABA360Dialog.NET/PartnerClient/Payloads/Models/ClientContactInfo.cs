using Newtonsoft.Json;

namespace WABA360Dialog.PartnerClient.Payloads.Models
{
    public class ClientContactInfo
    {
        [JsonProperty("webpage_url")]
        public string WebpageUrl { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("street_name")]
        public string StreetName { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("zip_code")]
        public string ZipCode { get; set; }
    }
}