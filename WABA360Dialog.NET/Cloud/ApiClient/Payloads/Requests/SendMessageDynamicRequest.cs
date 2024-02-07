using System.Net.Http;
using WABA360Dialog.Cloud.ApiClient.Payloads.Responses;

namespace WABA360Dialog.Cloud.ApiClient.Payloads.Requests
{
    internal class SendMessageDynamicRequest : WABA360Dialog.ApiClient.Payloads.Base.ClientApiRequestBase<SendMessageResponse>
    {
        public SendMessageDynamicRequest(object message) : base("messages", HttpMethod.Post)
        {
            Message = message;
        }

        public object Message { get; }

        public override HttpContent ToHttpContent()
        {
            return ToHttpJsonContent(Message);
        }
    }
}