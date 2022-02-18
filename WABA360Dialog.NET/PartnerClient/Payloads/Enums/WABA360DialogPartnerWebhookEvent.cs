using Newtonsoft.Json;
using WABA360Dialog.PartnerClient.Converters;

namespace WABA360Dialog.PartnerClient.Payloads.Enums
{
    [JsonConverter(typeof(WABA360DialogPartnerWebhookEventConverter))]
    public enum WABA360DialogPartnerWebhookEvent
    {
        Unknown = 0,
        ChannelSubmitted = 1,
        ChannelLive = 2,
        CancellationRequest = 3,
        CancellationRevoke = 4,
        CancellationProcessed = 5,
        ChannelCreated = 6,
        ChannelRunning = 7,
        ChannelReady = 8,
    }
}