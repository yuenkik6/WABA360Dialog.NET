using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Base;
using WABA360Dialog.ApiClient.Payloads.Models;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects;
using WABA360Dialog.Common.Helpers;

namespace WABA360Dialog.ApiClient.Payloads
{
    public class SendMessageRequest : ClientApiRequestBase<SendMessageResponse>
    {
        public SendMessageRequest(MessageObject message) : base("v1/messages", HttpMethod.Post)
        {
            Message = message;
        }

        public MessageObject Message { get; }

        public override HttpContent ToHttpContent()
        {
            var payload = JsonHelper.SerializeObjectToJson(Message);

            var content = new StringContent(payload, Encoding.UTF8, "application/json");

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return content;
        }
    }

    public class SendMessageDynamicRequest : ClientApiRequestBase<SendMessageResponse>
    {
        public SendMessageDynamicRequest(object message) : base("v1/messages", HttpMethod.Post)
        {
            Message = message;
        }

        public object Message { get; }

        public override HttpContent ToHttpContent()
        {
            var payload = JsonHelper.SerializeObjectToJson(Message);

            var content = new StringContent(payload, Encoding.UTF8, "application/json");

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return content;
        }
    }
    
    public class SendMessageResponse : ClientApiResponseBase
    {
        [JsonProperty("messages")]
        public IEnumerable<SendMessageResult> CreatedMessages { get; set; }
    }

}