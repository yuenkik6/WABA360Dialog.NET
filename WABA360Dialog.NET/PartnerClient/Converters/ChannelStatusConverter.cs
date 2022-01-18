using System.Collections.Generic;
using WABA360Dialog.Common.Converters.Base;
using WABA360Dialog.PartnerClient.Payloads.Enums;

namespace WABA360Dialog.PartnerClient.Converters
{
    internal class ChannelStatusConverter : EnumConverter<ChannelStatus>
    {
        protected override ChannelStatus GetEnumValue(string value) =>
            EnumStringConverter.GetChannelStatus(value);

        protected override string GetStringValue(ChannelStatus value) => value.GetString();
    }
    
    public static partial class EnumStringConverter
    {
        private static readonly IReadOnlyDictionary<string, ChannelStatus> ChannelStatusStringToEnum =
            new Dictionary<string, ChannelStatus>
            {
                { "unknown", ChannelStatus.unknown },
                { "created", ChannelStatus.created },
                { "unverified", ChannelStatus.unverified },
                { "verified", ChannelStatus.verified },
                { "ready", ChannelStatus.ready },
                { "modified", ChannelStatus.modified },
                { "imported", ChannelStatus.imported },
                { "new_name_requested", ChannelStatus.new_name_requested },
                { "certificate_declined", ChannelStatus.certificate_declined },
                { "consents_signed", ChannelStatus.consents_signed },
                { "error", ChannelStatus.error },
                { "porting_ready", ChannelStatus.porting_ready },
                { "ready_for_migration", ChannelStatus.ready_for_migration },
                { "waiting_for_migration_code", ChannelStatus.waiting_for_migration_code },
                { "migration_code_requested", ChannelStatus.migration_code_requested },
            };

        private static readonly IReadOnlyDictionary<ChannelStatus, string> ChannelStatusEnumToString =
            new Dictionary<ChannelStatus, string>
            {
                { ChannelStatus.unknown, "unknown" },
                { ChannelStatus.created, "created" },
                { ChannelStatus.unverified, "unverified" },
                { ChannelStatus.verified, "verified" },
                { ChannelStatus.ready, "ready" },
                { ChannelStatus.modified, "modified" },
                { ChannelStatus.imported, "imported" },
                { ChannelStatus.new_name_requested, "new_name_requested" },
                { ChannelStatus.certificate_declined, "certificate_declined" },
                { ChannelStatus.consents_signed, "consents_signed" },
                { ChannelStatus.error, "error" },
                { ChannelStatus.porting_ready, "porting_ready" },
                { ChannelStatus.ready_for_migration, "ready_for_migration" },
                { ChannelStatus.waiting_for_migration_code, "waiting_for_migration_code" },
                { ChannelStatus.migration_code_requested, "migration_code_requested" },
            };

        public static string GetString(this ChannelStatus status) =>
            ChannelStatusEnumToString.TryGetValue(status, out var stringValue)
                ? stringValue
                : "unknown";

        public static ChannelStatus GetChannelStatus(string status) =>
            ChannelStatusStringToEnum.TryGetValue(status, out var enumValue)
                ? enumValue
                : 0;
    }
}