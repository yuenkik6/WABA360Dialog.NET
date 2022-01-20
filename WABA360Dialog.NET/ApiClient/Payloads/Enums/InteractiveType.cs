using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Models.Converters;

namespace WABA360Dialog.ApiClient.Payloads.Enums
{
    [JsonConverter(typeof(InteractiveTypeConverter))]
    public enum InteractiveType
    {
        list = 1,
        button = 2,
        product = 3,
        product_list = 4
    }
}