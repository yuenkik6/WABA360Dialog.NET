using System.Collections.Generic;
using WABA360Dialog.Common.Converters.Base;
using WABA360Dialog.PartnerClient.WebhookEventModels.Enums;

namespace WABA360Dialog.PartnerClient.Converters
{
    internal class ThreeSixtyDialogPartnerWebhookEventConverter : EnumConverter<ThreeSixtyDialogPartnerWebhookEvent>
    {
        protected override ThreeSixtyDialogPartnerWebhookEvent GetEnumValue(string value) =>
            EnumStringConverter.GetThreeSixtyDialogPartnerWebhookEvent(value);

        protected override string GetStringValue(ThreeSixtyDialogPartnerWebhookEvent value) =>
            value.GetString();
    }

    
    public static partial class EnumStringConverter
    {
        private static readonly IReadOnlyDictionary<string, ThreeSixtyDialogPartnerWebhookEvent> ThreeSixtyDialogPartnerWebhookEventStringToEnum =
            new Dictionary<string, ThreeSixtyDialogPartnerWebhookEvent>
            {
                {"unknown", ThreeSixtyDialogPartnerWebhookEvent.Unknown},
                {"channel_submitted", ThreeSixtyDialogPartnerWebhookEvent.ChannelSubmitted},
                {"channel_live", ThreeSixtyDialogPartnerWebhookEvent.ChannelLive},
                {"cancellation_request", ThreeSixtyDialogPartnerWebhookEvent.CancellationRequest},
                {"cancellation_revoke", ThreeSixtyDialogPartnerWebhookEvent.CancellationRevoke},
                {"cancellation_processed", ThreeSixtyDialogPartnerWebhookEvent.CancellationProcessed}
            };

        private static readonly IReadOnlyDictionary<ThreeSixtyDialogPartnerWebhookEvent, string> ThreeSixtyDialogPartnerWebhookEventEnumToString =
            new Dictionary<ThreeSixtyDialogPartnerWebhookEvent, string>
            {
                {ThreeSixtyDialogPartnerWebhookEvent.Unknown, "unknown"},
                {ThreeSixtyDialogPartnerWebhookEvent.ChannelSubmitted, "channel_submitted"},
                {ThreeSixtyDialogPartnerWebhookEvent.ChannelLive, "channel_live"},
                {ThreeSixtyDialogPartnerWebhookEvent.CancellationRequest, "cancellation_request"},
                {ThreeSixtyDialogPartnerWebhookEvent.CancellationRevoke, "cancellation_revoke"},
                {ThreeSixtyDialogPartnerWebhookEvent.CancellationProcessed, "cancellation_processed"}
            };
        
        public static string GetString(this ThreeSixtyDialogPartnerWebhookEvent status) =>
            ThreeSixtyDialogPartnerWebhookEventEnumToString.TryGetValue(status, out var stringValue)
                ? stringValue
                : "unknown";

        public static ThreeSixtyDialogPartnerWebhookEvent GetThreeSixtyDialogPartnerWebhookEvent(string status) =>
            ThreeSixtyDialogPartnerWebhookEventStringToEnum.TryGetValue(status, out var enumValue)
                ? enumValue
                : 0;
    }

}
