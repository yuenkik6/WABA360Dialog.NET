using System.Collections.Generic;
using WABA360Dialog.Common.Converters.Base;
using WABA360Dialog.PartnerClient.Payloads.Enums;

namespace WABA360Dialog.PartnerClient.Converters
{
    internal class WABA360DialogPartnerWebhookEventConverter : EnumConverter<WABA360DialogPartnerWebhookEvent>
    {
        protected override WABA360DialogPartnerWebhookEvent GetEnumValue(string value) =>
            EnumStringConverter.GetWABA360DialogPartnerWebhookEvent(value);

        protected override string GetStringValue(WABA360DialogPartnerWebhookEvent value) =>
            value.GetString();
    }

    
    public static partial class EnumStringConverter
    {
        private static readonly IReadOnlyDictionary<string, WABA360DialogPartnerWebhookEvent> WABA360DialogPartnerWebhookEventStringToEnum =
            new Dictionary<string, WABA360DialogPartnerWebhookEvent>
            {
                {"unknown", WABA360DialogPartnerWebhookEvent.Unknown},
                {"channel_submitted", WABA360DialogPartnerWebhookEvent.ChannelSubmitted},
                {"channel_live", WABA360DialogPartnerWebhookEvent.ChannelLive},
                {"cancellation_request", WABA360DialogPartnerWebhookEvent.CancellationRequest},
                {"cancellation_revoke", WABA360DialogPartnerWebhookEvent.CancellationRevoke},
                {"cancellation_processed", WABA360DialogPartnerWebhookEvent.CancellationProcessed}
            };

        private static readonly IReadOnlyDictionary<WABA360DialogPartnerWebhookEvent, string> WABA360DialogPartnerWebhookEventEnumToString =
            new Dictionary<WABA360DialogPartnerWebhookEvent, string>
            {
                {WABA360DialogPartnerWebhookEvent.Unknown, "unknown"},
                {WABA360DialogPartnerWebhookEvent.ChannelSubmitted, "channel_submitted"},
                {WABA360DialogPartnerWebhookEvent.ChannelLive, "channel_live"},
                {WABA360DialogPartnerWebhookEvent.CancellationRequest, "cancellation_request"},
                {WABA360DialogPartnerWebhookEvent.CancellationRevoke, "cancellation_revoke"},
                {WABA360DialogPartnerWebhookEvent.CancellationProcessed, "cancellation_processed"}
            };
        
        public static string GetString(this WABA360DialogPartnerWebhookEvent status) =>
            WABA360DialogPartnerWebhookEventEnumToString.TryGetValue(status, out var stringValue)
                ? stringValue
                : "unknown";

        public static WABA360DialogPartnerWebhookEvent GetWABA360DialogPartnerWebhookEvent(string status) =>
            WABA360DialogPartnerWebhookEventStringToEnum.TryGetValue(status, out var enumValue)
                ? enumValue
                : 0;
    }

}
