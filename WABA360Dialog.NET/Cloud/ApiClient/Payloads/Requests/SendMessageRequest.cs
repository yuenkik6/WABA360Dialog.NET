using System.Net.Http;
using WABA360Dialog.Cloud.ApiClient.Payloads.Models.MessageObjects;
using WABA360Dialog.Cloud.ApiClient.Payloads.Responses;

namespace WABA360Dialog.Cloud.ApiClient.Payloads.Requests
{
    public class SendMessageRequest : WABA360Dialog.ApiClient.Payloads.Base.ClientApiRequestBase<SendMessageResponse>
    {
        public SendMessageRequest(MessageObject message) : base("messages", HttpMethod.Post)
        {
            Message = message;
        }

        public MessageObject Message { get; }

        public override HttpContent ToHttpContent()
        {
            return ToHttpJsonContent(Message);
        }
    }
}