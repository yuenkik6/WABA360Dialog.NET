using Newtonsoft.Json;
using System.Net.Http;
using WABA360Dialog.Cloud.ApiClient.Payloads.Responses;

namespace WABA360Dialog.Cloud.ApiClient.Payloads.Requests
{
    internal class MarkMessagesAsReadRequest : WABA360Dialog.ApiClient.Payloads.Base.ClientApiRequestBase<MarkMessagesAsReadResponse>
    {
        public MarkMessagesAsReadRequest(string messageId) : base($"messages/{messageId}", HttpMethod.Put)
        {
            MessageId = messageId;
        }

        public string MessageId { get; }

        public override HttpContent ToHttpContent()
        {
            return ToHttpJsonContent(new MarkMessageAsReadRequestBody { Status = "read" });
        }

        private class MarkMessageAsReadRequestBody
        {
            [JsonProperty("status")]
            public string Status { get; set; }
        }
    }
}