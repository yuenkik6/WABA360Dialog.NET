using System.Collections.Generic;
using WABA360Dialog.ApiClient.Payloads.Enums;
using WABA360Dialog.Common.Converters.Base;

namespace WABA360Dialog.ApiClient.Payloads.Models.Converters
{
    internal class PlaceTypeConverter : EnumConverter<PlaceType>
    {
        protected override PlaceType GetEnumValue(string value) =>
            EnumStringConverter.GetPlaceType(value);

        protected override string GetStringValue(PlaceType value) =>
            value.GetString();
    }
    
    public static partial class EnumStringConverter
    {
        private static readonly IReadOnlyDictionary<string, PlaceType> PlaceTypeStringToEnum =
            new Dictionary<string, PlaceType>
            {
                { "HOME", PlaceType.HOME },
                { "WORK", PlaceType.WORK },
            };


        private static readonly IReadOnlyDictionary<PlaceType, string> PlaceTypeEnumToString =
            new Dictionary<PlaceType, string>
            {
                { PlaceType.HOME, "HOME" },
                { PlaceType.WORK, "WORK" },
            };
        public static string GetString(this PlaceType status) =>
            PlaceTypeEnumToString.TryGetValue(status, out var stringValue)
                ? stringValue
                : "unknown";

        public static PlaceType GetPlaceType(string status) =>
            PlaceTypeStringToEnum.TryGetValue(status, out var enumValue)
                ? enumValue
                : 0;
    }
}