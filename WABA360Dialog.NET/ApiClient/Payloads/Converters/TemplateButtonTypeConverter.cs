using System.Collections.Generic;
using WABA360Dialog.ApiClient.Payloads.Enums;
using WABA360Dialog.Common.Converters.Base;

namespace WABA360Dialog.ApiClient.Payloads.Converters
{
    internal class TemplateButtonTypeConverter : EnumConverter<TemplateButtonType>
    {
        protected override TemplateButtonType GetEnumValue(string value) =>
            EnumStringConverter.GetTemplateButtonType(value);

        protected override string GetStringValue(TemplateButtonType value) =>
            value.GetString();
    }

    public static partial class EnumStringConverter
    {
        private static readonly IReadOnlyDictionary<string, TemplateButtonType> TemplateButtonTypeStringToEnum =
            new Dictionary<string, TemplateButtonType>
            {
                { "PHONE_NUMBER", TemplateButtonType.PHONE_NUMBER },
                { "URL", TemplateButtonType.URL },
                { "QUICK_REPLY", TemplateButtonType.QUICK_REPLY },
            };


        private static readonly IReadOnlyDictionary<TemplateButtonType, string> TemplateButtonTypeEnumToString =
            new Dictionary<TemplateButtonType, string>
            {
                { TemplateButtonType.PHONE_NUMBER, "PHONE_NUMBER" },
                { TemplateButtonType.URL, "URL" },
                { TemplateButtonType.QUICK_REPLY, "QUICK_REPLY" },
            };

        public static string GetString(this TemplateButtonType status) =>
            TemplateButtonTypeEnumToString.TryGetValue(status, out var stringValue)
                ? stringValue
                : "unknown";

        public static TemplateButtonType GetTemplateButtonType(string status) =>
            TemplateButtonTypeStringToEnum.TryGetValue(status, out var enumValue)
                ? enumValue
                : 0;
    }
}