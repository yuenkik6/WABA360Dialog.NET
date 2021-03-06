using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Converters;

namespace WABA360Dialog.ApiClient.Payloads.Enums
{
    [JsonConverter(typeof(HeaderTypeConverter))]
    public enum HeaderType
    {
        text,
        video,
        image,
        document
    }
}