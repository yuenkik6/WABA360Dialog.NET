using Newtonsoft.Json;
using System.Collections.Generic;

namespace WABA360Dialog.Cloud.ApiClient.Payloads.Responses
{
    public class GetWebhookUrlResponse : WABA360Dialog.ApiClient.Payloads.Base.ClientApiResponseBase
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("headers")]
        public Dictionary<string, string> Headers { get; set; }
    }
}