using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Models.Converters;

namespace WABA360Dialog.ApiClient.Payloads.Enums
{
    [JsonConverter(typeof(ExtendedPlaceTypeConverter))]
    public enum ExtendedPlaceType
    {
        CELL = 1,
        MAIN = 2,
        IPHONE = 3,
        HOME = 4,
        WORK = 5
    }
}