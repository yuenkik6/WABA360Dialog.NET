using System.Collections.Generic;
using WABA360Dialog.Common.Converters.Base;
using WABA360Dialog.PartnerClient.Payloads.Enums;

namespace WABA360Dialog.PartnerClient.Converters
{
    internal class BusinessInfoStatusConverter : EnumConverter<BusinessInfoStatus>
    {
        protected override BusinessInfoStatus GetEnumValue(string value) =>
            EnumStringConverter.GetBusinessInfoStatus(value);

        protected override string GetStringValue(BusinessInfoStatus value) => value.GetString();
    }

    public static partial class EnumStringConverter
    {
        private static readonly IReadOnlyDictionary<string, BusinessInfoStatus> BusinessInfoStatusStringToEnum =
            new Dictionary<string, BusinessInfoStatus>
            {
                { "unknown", BusinessInfoStatus.unknown },
                { "submitted", BusinessInfoStatus.submitted },
                { "approved", BusinessInfoStatus.approved },
                { "rejected", BusinessInfoStatus.rejected },
                { "denied", BusinessInfoStatus.denied },
            };

        private static readonly IReadOnlyDictionary<BusinessInfoStatus, string> BusinessInfoStatusEnumToString =
            new Dictionary<BusinessInfoStatus, string>
            {
                { BusinessInfoStatus.unknown, "unknown" },
                { BusinessInfoStatus.submitted, "submitted" },
                { BusinessInfoStatus.approved, "approved" },
                { BusinessInfoStatus.rejected, "rejected" },
                { BusinessInfoStatus.denied, "denied" },
            };

        public static string GetString(this BusinessInfoStatus status) =>
            BusinessInfoStatusEnumToString.TryGetValue(status, out var stringValue)
                ? stringValue
                : "unknown";

        public static BusinessInfoStatus GetBusinessInfoStatus(string status) =>
            BusinessInfoStatusStringToEnum.TryGetValue(status, out var enumValue)
                ? enumValue
                : 0;
    }
}