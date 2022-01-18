using System.Collections.Generic;
using WABA360Dialog.Common.Converters.Base;
using WABA360Dialog.PartnerClient.Payloads.Enums;

namespace WABA360Dialog.PartnerClient.Converters
{
    internal class VerificationMethodConverter : EnumConverter<VerificationMethod>
    {
        protected override VerificationMethod GetEnumValue(string value) =>
            EnumStringConverter.GetVerificationMethod(value);

        protected override string GetStringValue(VerificationMethod value) =>
            value.GetString();
    }

    public static partial class EnumStringConverter
    {
        private static readonly IReadOnlyDictionary<string, VerificationMethod> VerificationMethodStringToEnum =
            new Dictionary<string, VerificationMethod>
            {
                { "unknown", VerificationMethod.unknown },
                { "voice", VerificationMethod.voice },
                { "sms", VerificationMethod.sms },
            };

        private static readonly IReadOnlyDictionary<VerificationMethod, string> VerificationMethodEnumToString =
            new Dictionary<VerificationMethod, string>
            {
                { VerificationMethod.unknown, "unknown" },
                { VerificationMethod.voice, "voice" },
                { VerificationMethod.sms, "sms" },
            };
        public static string GetString(this VerificationMethod status) =>
            VerificationMethodEnumToString.TryGetValue(status, out var stringValue)
                ? stringValue
                : "unknown";

        public static VerificationMethod GetVerificationMethod(string status) =>
            VerificationMethodStringToEnum.TryGetValue(status, out var enumValue)
                ? enumValue
                : 0;
    }
    
}