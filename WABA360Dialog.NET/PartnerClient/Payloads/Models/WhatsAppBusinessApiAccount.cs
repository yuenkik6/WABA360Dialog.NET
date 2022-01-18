using Newtonsoft.Json;
using WABA360Dialog.PartnerClient.Payloads.Enums;

namespace WABA360Dialog.PartnerClient.Payloads.Models
{
    public class WhatsAppBusinessApiAccount
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("fb_account_status")]
        public FacebookAccountStatus FacebookAccountStatus { get; set; }

        [JsonProperty("on_behalf_of_business_info")]
        public OnBehalfOfBusinessInfo OnBehalfOfBusinessInfo { get; set; }
    }
}