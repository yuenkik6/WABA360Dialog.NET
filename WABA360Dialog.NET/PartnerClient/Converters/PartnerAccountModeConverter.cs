using System.Collections.Generic;
using WABA360Dialog.Common.Converters.Base;
using WABA360Dialog.PartnerClient.Payloads.Enums;

namespace WABA360Dialog.PartnerClient.Converters
{
    internal class PartnerAccountModeConverter : EnumConverter<PartnerAccountMode>
    {
        protected override PartnerAccountMode GetEnumValue(string value) =>
            EnumStringConverter.GetPartnerAccountMode(value);

        protected override string GetStringValue(PartnerAccountMode value) =>
            value.GetString();
    }

    public static partial class EnumStringConverter
    {
        private static readonly IReadOnlyDictionary<string, PartnerAccountMode> PartnerAccountModeStringToEnum =
            new Dictionary<string, PartnerAccountMode>
            {
                { "unknown", PartnerAccountMode.unknown },
                { "sandbox", PartnerAccountMode.sandbox },
                { "live", PartnerAccountMode.live },
            };

        private static readonly IReadOnlyDictionary<PartnerAccountMode, string> PartnerAccountModeEnumToString =
            new Dictionary<PartnerAccountMode, string>
            {
                { PartnerAccountMode.unknown, "unknown" },
                { PartnerAccountMode.sandbox, "sandbox" },
                { PartnerAccountMode.live, "live" },
            };

        public static string GetString(this PartnerAccountMode status) =>
            PartnerAccountModeEnumToString.TryGetValue(status, out var stringValue)
                ? stringValue
                : "unknown";

        public static PartnerAccountMode GetPartnerAccountMode(string status) =>
            PartnerAccountModeStringToEnum.TryGetValue(status, out var enumValue)
                ? enumValue
                : 0;
    }
}