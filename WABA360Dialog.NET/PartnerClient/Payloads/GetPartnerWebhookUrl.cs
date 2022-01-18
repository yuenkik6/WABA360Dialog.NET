using System.Net.Http;
using Newtonsoft.Json;
using WABA360Dialog.PartnerClient.Payloads.Base;

namespace WABA360Dialog.PartnerClient.Payloads
{
    public class GetPartnerWebhookUrlRequest : PartnerApiRequestBase<GetPartnerWebhookUrlResponse>
    {
        public GetPartnerWebhookUrlRequest(string partnerId) : base($"partners/{partnerId}/webhook_url", HttpMethod.Get)
        {
            PartnerId = partnerId;
        }

        [JsonIgnore]
        public string PartnerId { get; }
    }

    public class GetPartnerWebhookUrlResponse : PartnerApiResponseBase
    {
        [JsonProperty("webhook_url")]
        public string WebhookUrl { get; set; }
    }

}