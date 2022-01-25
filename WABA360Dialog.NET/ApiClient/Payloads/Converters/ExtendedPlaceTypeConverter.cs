using System.Collections.Generic;
using WABA360Dialog.ApiClient.Payloads.Enums;
using WABA360Dialog.Common.Converters.Base;

namespace WABA360Dialog.ApiClient.Payloads.Converters
{
    internal class ExtendedPlaceTypeConverter : EnumConverter<ExtendedPlaceType>
    {
        protected override ExtendedPlaceType GetEnumValue(string value) =>
            EnumStringConverter.GetExtendedPlaceType(value);

        protected override string GetStringValue(ExtendedPlaceType value) =>
            value.GetString();
    }
    
    public static partial class EnumStringConverter
    {
        private static readonly IReadOnlyDictionary<string, ExtendedPlaceType> ExtendedPlaceTypeStringToEnum =
            new Dictionary<string, ExtendedPlaceType>
            {
                { "CELL", ExtendedPlaceType.CELL },
                { "MAIN", ExtendedPlaceType.MAIN },
                { "IPHONE", ExtendedPlaceType.IPHONE },
                { "HOME", ExtendedPlaceType.HOME },
                { "WORK", ExtendedPlaceType.WORK },
            };


        private static readonly IReadOnlyDictionary<ExtendedPlaceType, string> ExtendedPlaceTypeEnumToString =
            new Dictionary<ExtendedPlaceType, string>
            {
                { ExtendedPlaceType.CELL, "CELL" },
                { ExtendedPlaceType.MAIN, "MAIN" },
                { ExtendedPlaceType.IPHONE, "IPHONE" },
                { ExtendedPlaceType.HOME, "HOME" },
                { ExtendedPlaceType.WORK, "WORK" },
            };
        public static string GetString(this ExtendedPlaceType status) =>
            ExtendedPlaceTypeEnumToString.TryGetValue(status, out var stringValue)
                ? stringValue
                : "unknown";

        public static ExtendedPlaceType GetExtendedPlaceType(string status) =>
            ExtendedPlaceTypeStringToEnum.TryGetValue(status, out var enumValue)
                ? enumValue
                : 0;
    }
}