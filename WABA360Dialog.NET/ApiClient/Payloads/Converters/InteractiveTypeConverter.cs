using System.Collections.Generic;
using WABA360Dialog.ApiClient.Payloads.Enums;
using WABA360Dialog.Common.Converters.Base;

namespace WABA360Dialog.ApiClient.Payloads.Converters
{
    internal class InteractiveTypeConverter : EnumConverter<InteractiveType>
    {
        protected override InteractiveType GetEnumValue(string value) =>
            EnumStringConverter.GetInteractiveType(value);

        protected override string GetStringValue(InteractiveType value) =>
            value.GetString();
    }
    
    public static partial class EnumStringConverter
    {
        private static readonly IReadOnlyDictionary<string, InteractiveType> InteractiveTypeStringToEnum =
            new Dictionary<string, InteractiveType>
            {
                { "list", InteractiveType.list },
                { "button", InteractiveType.button },
                { "product", InteractiveType.product },
                { "product_list", InteractiveType.product_list },
            };


        private static readonly IReadOnlyDictionary<InteractiveType, string> InteractiveTypeEnumToString =
            new Dictionary<InteractiveType, string>
            {
                { InteractiveType.list, "list" },
                { InteractiveType.button, "button" },
                { InteractiveType.product, "product" },
                { InteractiveType.product_list, "product_list" },
            };

        public static string GetString(this InteractiveType status) =>
            InteractiveTypeEnumToString.TryGetValue(status, out var stringValue)
                ? stringValue
                : "unknown";

        public static InteractiveType GetInteractiveType(string status) =>
            InteractiveTypeStringToEnum.TryGetValue(status, out var enumValue)
                ? enumValue
                : 0;
    }
}