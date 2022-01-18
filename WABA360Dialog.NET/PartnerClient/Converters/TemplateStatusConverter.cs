using System.Collections.Generic;
using WABA360Dialog.Common.Converters.Base;
using WABA360Dialog.PartnerClient.Payloads.Enums;

namespace WABA360Dialog.PartnerClient.Converters
{
    internal class TemplateStatusConverter : EnumConverter<TemplateStatus>
    {
        protected override TemplateStatus GetEnumValue(string value) =>
            EnumStringConverter.GetTemplateStatus(value);

        protected override string GetStringValue(TemplateStatus value) =>
            value.GetString();
    }

    public static partial class EnumStringConverter
    {
        private static readonly IReadOnlyDictionary<string, TemplateStatus> TemplateStatusStringToEnum =
            new Dictionary<string, TemplateStatus>
            {
                { "unknown", TemplateStatus.unknown },
                { "created", TemplateStatus.created },
                { "submitted", TemplateStatus.submitted },
                { "pending", TemplateStatus.pending },
                { "approved", TemplateStatus.approved },
                { "rejected", TemplateStatus.rejected },
            };


        private static readonly IReadOnlyDictionary<TemplateStatus, string> TemplateStatusEnumToString =
            new Dictionary<TemplateStatus, string>
            {
                { TemplateStatus.unknown, "unknown" },
                { TemplateStatus.created, "created" },
                { TemplateStatus.submitted, "submitted" },
                { TemplateStatus.pending, "pending" },
                { TemplateStatus.approved, "approved" },
                { TemplateStatus.rejected, "rejected" },
            };
        public static string GetString(this TemplateStatus status) =>
            TemplateStatusEnumToString.TryGetValue(status, out var stringValue)
                ? stringValue
                : "unknown";

        public static TemplateStatus GetTemplateStatus(string status) =>
            TemplateStatusStringToEnum.TryGetValue(status, out var enumValue)
                ? enumValue
                : 0;
    }
}