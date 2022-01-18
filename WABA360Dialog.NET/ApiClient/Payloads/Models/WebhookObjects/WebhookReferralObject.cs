using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.WebhookObjects
{
    public class WebhookReferralObject
    {
        [JsonProperty("headline")]
        public string Headline { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("source_type")]
        public string SourceType { get; set; }

        [JsonProperty("source_id")]
        public string SourceId { get; set; }

        [JsonProperty("source_url")]
        public string SourceUrl { get; set; }

        [JsonProperty("video")]
        public WebhookMediaObject Video { get; set; }

        [JsonProperty("image")]
        public WebhookMediaObject Image { get; set; }
    }
}