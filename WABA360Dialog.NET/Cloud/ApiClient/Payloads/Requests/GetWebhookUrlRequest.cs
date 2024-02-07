using System.Net.Http;
using WABA360Dialog.Cloud.ApiClient.Payloads.Responses;

namespace WABA360Dialog.Cloud.ApiClient.Payloads.Requests
{
    public class GetWebhookUrlRequest : WABA360Dialog.ApiClient.Payloads.Base.ClientApiRequestBase<GetWebhookUrlResponse>
    {
        public GetWebhookUrlRequest() : base("waba_webhook", HttpMethod.Get)
        {

        }
    }
}