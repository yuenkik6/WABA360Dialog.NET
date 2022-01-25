using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Converters;

namespace WABA360Dialog.ApiClient.Payloads.Enums
{
    [JsonConverter(typeof(ButtonTypeConverter))]
    public enum ButtonType
    {
        reply = 1,
        quick_reply = 2,
        url = 3
    }

}