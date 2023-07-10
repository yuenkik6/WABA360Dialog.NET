using System.Net.Http;
using Newtonsoft.Json;
using WABA360Dialog.PartnerClient.Payloads.Base;

namespace WABA360Dialog.PartnerClient.Payloads
{
    public class GetPartnerPublicDataRequest : PartnerApiRequestBase<GetPartnerPublicDataResponse>
    {
        public GetPartnerPublicDataRequest(string partnerId)
            : base($"partners/{partnerId}", HttpMethod.Get)
        {
            PartnerId = partnerId;
        }

        [JsonIgnore]
        public string PartnerId { get; }

    }

    public class GetPartnerPublicDataResponse : PartnerApiResponseBase
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

        [JsonProperty("blocked_new_submission")]
        public bool BlockedNewSubmission { get; set; }
        
        [JsonProperty("country")]
        public string Country { get; set; }
        
        [JsonProperty("payment_required")]
        public bool PaymentRequired { get; set; }

        [JsonProperty("webhook_url")]
        public string WebhookUrl { get; set; }
    }
}