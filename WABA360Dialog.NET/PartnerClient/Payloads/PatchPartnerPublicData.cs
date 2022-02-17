using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using WABA360Dialog.PartnerClient.Payloads.Base;
using WABA360Dialog.PartnerClient.Payloads.Models;

namespace WABA360Dialog.PartnerClient.Payloads
{
    public class PatchPartnerPublicDataRequest : PartnerApiRequestBase<PatchPartnerPublicDataResponse>
    {
        public PatchPartnerPublicDataRequest(string partnerId, string webhookUrl, string partnerRedirectUrl)
            : base($"partners/{partnerId}", new HttpMethod("PATCH"))
        {
            PartnerId = partnerId;
            WebhookUrl = webhookUrl;
            PartnerRedirectUrl = partnerRedirectUrl;
        }

        [JsonIgnore]
        public string PartnerId { get; }

        [JsonProperty("partner_redirect_url")]
        public string PartnerRedirectUrl { get; set; }
        
        [JsonProperty("webhook_url")]
        public string WebhookUrl { get; set; }
    }

    public class PatchPartnerPublicDataResponse : PartnerApiResponseBase
    {
        [JsonProperty("brand_name")]
        public string BrandName { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("logo_url")]
        public string LogoUrl { get; set; }

        [JsonProperty("onboarding_deeplink_add_params")]
        public bool OnBoardingDeeplinkAddParams { get; set; }

        [JsonProperty("partner_redirect_url")]
        public string PartnerRedirectUrl { get; set; }

        [JsonProperty("payment_plan")]
        public object PaymentPlan { get; set; }

        [JsonProperty("payment_required")]
        public bool PaymentRequired { get; set; }

        [JsonProperty("webhook_url")]
        public string WebhookUrl { get; set; }
    }
}