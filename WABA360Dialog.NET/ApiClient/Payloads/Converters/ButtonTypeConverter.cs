using System.Collections.Generic;
using WABA360Dialog.ApiClient.Payloads.Enums;
using WABA360Dialog.Common.Converters.Base;

namespace WABA360Dialog.ApiClient.Payloads.Converters
{
    internal class ButtonTypeConverter : EnumConverter<ButtonType>
    {
        protected override ButtonType GetEnumValue(string value) =>
            EnumStringConverter.GetButtonType(value);

        protected override string GetStringValue(ButtonType value) =>
            value.GetString();
    }

    public static partial class EnumStringConverter
    {
        private static readonly IReadOnlyDictionary<string, ButtonType> ButtonTypeStringToEnum =
            new Dictionary<string, ButtonType>
            {
                { "reply", ButtonType.reply },
                { "quick_reply", ButtonType.quick_reply },
                { "url", ButtonType.url },
            };


        private static readonly IReadOnlyDictionary<ButtonType, string> ButtonTypeEnumToString =
            new Dictionary<ButtonType, string>
            {
                { ButtonType.reply, "reply" },
                { ButtonType.quick_reply, "quick_reply" },
                { ButtonType.url, "url" },
            };

        public static string GetString(this ButtonType status) =>
            ButtonTypeEnumToString.TryGetValue(status, out var stringValue)
                ? stringValue
                : "unknown";

        public static ButtonType GetButtonType(string status) =>
            ButtonTypeStringToEnum.TryGetValue(status, out var enumValue)
                ? enumValue
                : 0;
    }
}