using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using WABA360Dialog.Cloud.ApiClient.Payloads.Responses;

namespace WABA360Dialog.Cloud.ApiClient.Payloads.Requests
{
    public class SetWebhookUrlRequest : WABA360Dialog.ApiClient.Payloads.Base.ClientApiRequestBase<SetWebhookUrlResponse>
    {
        public SetWebhookUrlRequest(string url, Dictionary<string, string> headers) : base("waba_webhook", HttpMethod.Post)
        {
            Url = url;
            Headers = headers;
        }
       
        [JsonProperty("url")]
        public string Url { get; }

        [JsonProperty("headers")]
        public Dictionary<string, string> Headers { get; }
    }
}