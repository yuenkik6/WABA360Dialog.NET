using Newtonsoft.Json;
using WABA360Dialog.PartnerClient.Payloads.Models;
using WABA360Dialog.PartnerClient.WebhookEventModels.Enums;

namespace WABA360Dialog.PartnerClient.WebhookEventModels
{
    public class ThreeSixtyDialogPartnerWebhookEventPayload
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("event")]
        public ThreeSixtyDialogPartnerWebhookEvent Event { get; set; }

        [JsonProperty("data")]
        public PartnerChannel Data { get; set; }
    }

}