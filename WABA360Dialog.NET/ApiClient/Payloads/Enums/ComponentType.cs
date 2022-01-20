using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Models.Converters;

namespace WABA360Dialog.ApiClient.Payloads.Enums
{
    [JsonConverter(typeof(ComponentTypeConverter))]
    public enum ComponentType
    {
        header = 1,
        body = 2,
        button = 3
    }
}