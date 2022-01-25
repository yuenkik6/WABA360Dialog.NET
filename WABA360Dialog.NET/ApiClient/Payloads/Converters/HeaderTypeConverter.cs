using System.Collections.Generic;
using WABA360Dialog.ApiClient.Payloads.Enums;
using WABA360Dialog.Common.Converters.Base;

namespace WABA360Dialog.ApiClient.Payloads.Converters
{    
    internal class HeaderTypeConverter : EnumConverter<HeaderType>
    {
        protected override HeaderType GetEnumValue(string value) =>
            EnumStringConverter.GetHeaderType(value);

        protected override string GetStringValue(HeaderType value) =>
            value.GetString();
    }

    public static partial class EnumStringConverter
    {
        private static readonly IReadOnlyDictionary<string, HeaderType> HeaderTypeStringToEnum =
            new Dictionary<string, HeaderType>
            {
                { "text", HeaderType.text },
                { "video", HeaderType.video },
                { "image", HeaderType.image },
                { "document", HeaderType.document },
            };


        private static readonly IReadOnlyDictionary<HeaderType, string> HeaderTypeEnumToString =
            new Dictionary<HeaderType, string>
            {
                { HeaderType.text, "text" },
                { HeaderType.video, "video" },
                { HeaderType.image, "image" },
                { HeaderType.document, "document" },
            };

        public static string GetString(this HeaderType status) =>
            HeaderTypeEnumToString.TryGetValue(status, out var stringValue)
                ? stringValue
                : "unknown";

        public static HeaderType GetHeaderType(string status) =>
            HeaderTypeStringToEnum.TryGetValue(status, out var enumValue)
                ? enumValue
                : 0;
    }
}