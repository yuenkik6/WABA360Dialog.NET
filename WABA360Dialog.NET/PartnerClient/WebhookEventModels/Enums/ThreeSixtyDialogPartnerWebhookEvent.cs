using Newtonsoft.Json;
using WABA360Dialog.PartnerClient.Converters;

namespace WABA360Dialog.PartnerClient.WebhookEventModels.Enums
{
    [JsonConverter(typeof(ThreeSixtyDialogPartnerWebhookEventConverter))]
    public enum ThreeSixtyDialogPartnerWebhookEvent
    {
        Unknown = 0,
        ChannelSubmitted = 1,
        ChannelLive = 2,
        CancellationRequest = 3,
        CancellationRevoke = 4,
        CancellationProcessed = 5,
    }
}