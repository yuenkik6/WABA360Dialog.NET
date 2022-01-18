using System.Collections.Generic;
using WABA360Dialog.Common.Converters.Base;
using WABA360Dialog.PartnerClient.Payloads.Enums;

namespace WABA360Dialog.PartnerClient.Converters
{
    internal class PartnerChannelStatusConverter : EnumConverter<PartnerChannelStatus>
    {
        protected override PartnerChannelStatus GetEnumValue(string value) =>
            EnumStringConverter.GetPartnerChannelStatus(value);

        protected override string GetStringValue(PartnerChannelStatus value) =>
            value.GetString();
    }

    public static partial class EnumStringConverter
    {
        private static readonly IReadOnlyDictionary<string, PartnerChannelStatus> PartnerChannelStatusStringToEnum =
            new Dictionary<string, PartnerChannelStatus>
            {
                { "unknown", PartnerChannelStatus.unknown },
                { "created", PartnerChannelStatus.created },
                { "unverified", PartnerChannelStatus.unverified },
                { "verified", PartnerChannelStatus.verified },
                { "ready", PartnerChannelStatus.ready },
                { "modified", PartnerChannelStatus.modified },
                { "imported", PartnerChannelStatus.imported },
                { "new_name_requested", PartnerChannelStatus.new_name_requested },
                { "certificate_declined", PartnerChannelStatus.certificate_declined },
                { "consents_signed", PartnerChannelStatus.consents_signed },
                { "error", PartnerChannelStatus.error },
                { "porting_ready", PartnerChannelStatus.porting_ready },
                { "ready_for_migration", PartnerChannelStatus.ready_for_migration },
                { "waiting_for_migration_code", PartnerChannelStatus.waiting_for_migration_code },
                { "migration_code_requested", PartnerChannelStatus.migration_code_requested },
            };

        private static readonly IReadOnlyDictionary<PartnerChannelStatus, string> PartnerChannelStatusEnumToString =
            new Dictionary<PartnerChannelStatus, string>
            {
                { PartnerChannelStatus.unknown, "unknown" },
                { PartnerChannelStatus.created, "created" },
                { PartnerChannelStatus.unverified, "unverified" },
                { PartnerChannelStatus.verified, "verified" },
                { PartnerChannelStatus.ready, "ready" },
                { PartnerChannelStatus.modified, "modified" },
                { PartnerChannelStatus.imported, "imported" },
                { PartnerChannelStatus.new_name_requested, "new_name_requested" },
                { PartnerChannelStatus.certificate_declined, "certificate_declined" },
                { PartnerChannelStatus.consents_signed, "consents_signed" },
                { PartnerChannelStatus.error, "error" },
                { PartnerChannelStatus.porting_ready, "porting_ready" },
                { PartnerChannelStatus.ready_for_migration, "ready_for_migration" },
                { PartnerChannelStatus.waiting_for_migration_code, "waiting_for_migration_code" },
                { PartnerChannelStatus.migration_code_requested, "migration_code_requested" },
            };

        public static string GetString(this PartnerChannelStatus status) =>
            PartnerChannelStatusEnumToString.TryGetValue(status, out var stringValue)
                ? stringValue
                : "unknown";

        public static PartnerChannelStatus GetPartnerChannelStatus(string status) =>
            PartnerChannelStatusStringToEnum.TryGetValue(status, out var enumValue)
                ? enumValue
                : 0;
    }
}