using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Models.Converters;

namespace WABA360Dialog.ApiClient.Payloads.Enums
{
    [JsonConverter(typeof(PlaceTypeConverter))]
    public enum PlaceType
    {
        HOME = 1,
        WORK = 2,
    }
}