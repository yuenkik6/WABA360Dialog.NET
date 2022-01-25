using System.Collections.Generic;
using WABA360Dialog.ApiClient.Payloads.Enums;
using WABA360Dialog.Common.Converters.Base;

namespace WABA360Dialog.ApiClient.Payloads.Converters
{
    internal class TemplateComponentTypeConverter : EnumConverter<TemplateComponentType>
    {
        protected override TemplateComponentType GetEnumValue(string value) =>
            EnumStringConverter.GetTemplateComponentType(value);

        protected override string GetStringValue(TemplateComponentType value) =>
            value.GetString();
    }

    public static partial class EnumStringConverter
    {
        private static readonly IReadOnlyDictionary<string, TemplateComponentType> TemplateComponentTypeStringToEnum =
            new Dictionary<string, TemplateComponentType>
            {
                { "BODY", TemplateComponentType.BODY },
                { "HEADER", TemplateComponentType.HEADER },
                { "FOOTER", TemplateComponentType.FOOTER },
                { "BUTTONS", TemplateComponentType.BUTTONS },
            };


        private static readonly IReadOnlyDictionary<TemplateComponentType, string> TemplateComponentTypeEnumToString =
            new Dictionary<TemplateComponentType, string>
            {
                { TemplateComponentType.BODY, "BODY" },
                { TemplateComponentType.HEADER, "HEADER" },
                { TemplateComponentType.FOOTER, "FOOTER" },
            };

        public static string GetString(this TemplateComponentType status) =>
            TemplateComponentTypeEnumToString.TryGetValue(status, out var stringValue)
                ? stringValue
                : "unknown";

        public static TemplateComponentType GetTemplateComponentType(string status) =>
            TemplateComponentTypeStringToEnum.TryGetValue(status, out var enumValue)
                ? enumValue
                : 0;
    }
}