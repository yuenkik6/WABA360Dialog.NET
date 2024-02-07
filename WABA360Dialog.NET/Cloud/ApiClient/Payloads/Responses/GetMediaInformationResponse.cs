using Newtonsoft.Json;
using WABA360Dialog.Cloud.ApiClient.Payloads.Enums;

namespace WABA360Dialog.Cloud.ApiClient.Payloads.Responses
{
    public class GetMediaInformationResponse : WABA360Dialog.ApiClient.Payloads.Base.ClientApiResponseBase
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("mime_type")]
        public string MimeType { get; set; }

        [JsonProperty("sha256")]
        public string Sha256 { get; set; }

        [JsonProperty("file_size")]
        public int FileSize { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("messaging_product")]
        public MessagingProduct MessagingProduct { get; set; }
    }
}