using System.Collections.Generic;
using WABA360Dialog.Common.Converters.Base;
using WABA360Dialog.PartnerClient.Payloads.Enums;

namespace WABA360Dialog.PartnerClient.Converters
{
    internal class AccountModeConverter : EnumConverter<AccountMode>
    {
        protected override AccountMode GetEnumValue(string value) =>
            EnumStringConverter.GetAccountMode(value);

        protected override string GetStringValue(AccountMode value) => value.GetString();
    }

    public static partial class EnumStringConverter
    {
        private static readonly IReadOnlyDictionary<string, AccountMode> AccountModeStringToEnum =
            new Dictionary<string, AccountMode>
            {
                { "sandbox", AccountMode.sandbox },
                { "live", AccountMode.live },
            };

        private static readonly IReadOnlyDictionary<AccountMode, string> AccountModeEnumToString =
            new Dictionary<AccountMode, string>
            {
                { AccountMode.sandbox, "sandbox" },
                { AccountMode.live, "live" },
            };

        public static string GetString(this AccountMode status) =>
            AccountModeEnumToString.TryGetValue(status, out var stringValue)
                ? stringValue
                : "unknown";

        public static AccountMode GetAccountMode(string status) =>
            AccountModeStringToEnum.TryGetValue(status, out var enumValue)
                ? enumValue
                : 0;
    }
}