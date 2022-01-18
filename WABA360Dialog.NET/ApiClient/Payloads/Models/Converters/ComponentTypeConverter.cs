using System.Collections.Generic;
using WABA360Dialog.ApiClient.Payloads.Enums;
using WABA360Dialog.Common.Converters.Base;

namespace WABA360Dialog.ApiClient.Payloads.Models.Converters
{
    internal class ComponentTypeConverter : EnumConverter<ComponentType>
    {
        protected override ComponentType GetEnumValue(string value) =>
            EnumStringConverter.GetComponentType(value);

        protected override string GetStringValue(ComponentType value) =>
            value.GetString();
    }
    
    public static partial class EnumStringConverter
    {
        private static readonly IReadOnlyDictionary<string, ComponentType> ComponentTypeStringToEnum =
            new Dictionary<string, ComponentType>
            {
                { "header", ComponentType.header },
                { "body", ComponentType.body },
                { "button", ComponentType.button },
            };

        private static readonly IReadOnlyDictionary<ComponentType, string> ComponentTypeEnumToString =
            new Dictionary<ComponentType, string>
            {
                { ComponentType.header, "header" },
                { ComponentType.body, "body" },
                { ComponentType.button, "button" },
            };

        public static string GetString(this ComponentType status) =>
            ComponentTypeEnumToString.TryGetValue(status, out var stringValue)
                ? stringValue
                : "unknown";

        public static ComponentType GetComponentType(string status) =>
            ComponentTypeStringToEnum.TryGetValue(status, out var enumValue)
                ? enumValue
                : 0;
    }
}