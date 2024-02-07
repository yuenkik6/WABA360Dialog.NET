using Newtonsoft.Json;

namespace WABA360Dialog.Cloud.ApiClient.Payloads.Responses
{
	public class UploadMediaResponse : WABA360Dialog.ApiClient.Payloads.Base.ClientApiResponseBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}