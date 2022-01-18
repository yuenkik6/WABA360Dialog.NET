using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.WebhookObjects
{
    public class WebhookVideoObject
    {
        [JsonProperty("file")]
        public string File { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("mime_type")]
        public string MimeType { get; set; }

        [JsonProperty("sha256")]
        public string Sha256 { get; set; }
    }
}