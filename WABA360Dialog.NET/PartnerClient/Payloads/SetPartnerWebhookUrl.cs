using System.Net.Http;
using Newtonsoft.Json;
using WABA360Dialog.PartnerClient.Payloads.Base;

namespace WABA360Dialog.PartnerClient.Payloads
{
    public class SetPartnerWebhookUrlRequest : PartnerApiRequestBase<SetPartnerWebhookUrlResponse>
    {
        public SetPartnerWebhookUrlRequest(string partnerId, string webhookUrl) : base($"partners/{partnerId}/webhook_url", HttpMethod.Post)
        {
            PartnerId = partnerId;
            WebhookUrl = webhookUrl;
        }

        [JsonIgnore]
        public string PartnerId { get; }

        [JsonProperty("webhook_url")]
        public string WebhookUrl { get; set; }
    }

    public class SetPartnerWebhookUrlResponse : PartnerApiResponseBase
    {
        [JsonProperty("webhook_url")]
        public string WebhookUrl { get; set; }

        [JsonProperty("brand_name")]
        public string BrandName { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("logo_url")]
        public string LogoUrl { get; set; }

        [JsonProperty("onboarding_deeplink_add_params")]
        public bool OnBoardingDeeplinkAddParams { get; set; }

        [JsonProperty("payment_plan")]
        public object PaymentPlan { get; set; }

        [JsonProperty("payment_required")]
        public bool PaymentRequired { get; set; }
    }

}