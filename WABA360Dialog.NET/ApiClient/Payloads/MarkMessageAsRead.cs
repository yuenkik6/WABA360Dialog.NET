using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Base;
using WABA360Dialog.Common.Helpers;

namespace WABA360Dialog.ApiClient.Payloads
{
    public class MarkMessagesAsReadRequest : ClientApiRequestBase<MarkMessagesAsReadResponse>
    {
        public MarkMessagesAsReadRequest(string messageId) : base($"v1/messages/{messageId}", HttpMethod.Put)
        {
            MessageId = messageId;
        }

        public string MessageId { get; }
        
        public override HttpContent ToHttpContent()
        {
            var payload = JsonHelper.SerializeObjectToJson(new MarkMessageAsReadRequestBody{ Status = "read"});

            var content = new StringContent(payload, Encoding.UTF8, "application/json");

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return content;
        }

        private class MarkMessageAsReadRequestBody
        {
            [JsonProperty("status")]
            public string Status { get; set; }
        }
    }

    public class MarkMessagesAsReadResponse : ClientApiResponseBase
    {
    }
}