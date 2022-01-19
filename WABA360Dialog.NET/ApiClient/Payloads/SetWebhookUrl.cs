using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Base;

namespace WABA360Dialog.ApiClient.Payloads
{
    public class SetWebhookUrlRequest : ClientApiRequestBase<SetWebhookUrlResponse>
    {
        public SetWebhookUrlRequest(string url, Dictionary<string, string> headers) : base("v1/configs/webhook", HttpMethod.Post)
        {
            Url = url;
            Headers = headers;
        }
        
        [JsonProperty("url")]
        public string Url { get; }
        
        [JsonProperty("headers")]
        public Dictionary<string, string> Headers { get; }
    }
    
    public class SetWebhookUrlResponse : ClientApiResponseBase
    {
        [JsonProperty("url")]
        public string Url { get; set; }
        
        [JsonProperty("headers")]
        public Dictionary<string, string> Headers { get; set; }
    }
}