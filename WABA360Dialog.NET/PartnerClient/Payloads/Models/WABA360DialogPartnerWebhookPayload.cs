using Newtonsoft.Json;
using WABA360Dialog.PartnerClient.WebhookEventModels.Enums;

namespace WABA360Dialog.PartnerClient.Payloads.Models
{
    public class WABA360DialogPartnerWebhookPayload
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("event")]
        public WABA360DialogPartnerWebhookEvent Event { get; set; }

        [JsonProperty("data")]
        public PartnerChannel Data { get; set; }
    }

}