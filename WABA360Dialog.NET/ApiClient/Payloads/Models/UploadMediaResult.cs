using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models
{
    public class UploadMediaResult
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}