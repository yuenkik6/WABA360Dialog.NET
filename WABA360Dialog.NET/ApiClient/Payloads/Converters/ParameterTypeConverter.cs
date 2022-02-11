using System.Collections.Generic;
using WABA360Dialog.ApiClient.Payloads.Enums;
using WABA360Dialog.Common.Converters.Base;

namespace WABA360Dialog.ApiClient.Payloads.Converters
{
    internal class ParameterTypeConverter : EnumConverter<ParameterType>
    {
        protected override ParameterType GetEnumValue(string value) =>
            EnumStringConverter.GetParameterType(value);

        protected override string GetStringValue(ParameterType value) =>
            value.GetString();
    }
    
    public static partial class EnumStringConverter
    {
        private static readonly IReadOnlyDictionary<string, ParameterType> ParameterTypeStringToEnum =
            new Dictionary<string, ParameterType>
            {
                { "text", ParameterType.text },
                { "currency", ParameterType.currency },
                { "date_time", ParameterType.date_time },
                { "image", ParameterType.image },
                { "document", ParameterType.document },
                { "video", ParameterType.video },
                { "payload", ParameterType.payload },
            };


        private static readonly IReadOnlyDictionary<ParameterType, string> ParameterTypeEnumToString =
            new Dictionary<ParameterType, string>
            {
                { ParameterType.text, "text" },
                { ParameterType.currency, "currency" },
                { ParameterType.date_time, "date_time" },
                { ParameterType.image, "image" },
                { ParameterType.document, "document" },
                { ParameterType.video, "video" },
                { ParameterType.payload, "payload" },
            };

        public static string GetString(this ParameterType status) =>
            ParameterTypeEnumToString.TryGetValue(status, out var stringValue)
                ? stringValue
                : "unknown";

        public static ParameterType GetParameterType(string status) =>
            ParameterTypeStringToEnum.TryGetValue(status, out var enumValue)
                ? enumValue
                : 0;
    }
}