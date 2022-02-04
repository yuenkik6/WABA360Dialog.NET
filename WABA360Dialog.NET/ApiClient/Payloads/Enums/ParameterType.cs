using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Converters;

namespace WABA360Dialog.ApiClient.Payloads.Enums
{
    [JsonConverter(typeof(ParameterTypeConverter))]
    public enum ParameterType
    {
        text = 1,
        currency = 2,
        date_time = 3,
        image = 4,
        document = 5,
        video = 6,
        payload = 7,
    }
}