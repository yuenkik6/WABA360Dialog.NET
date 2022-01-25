using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Converters;

namespace WABA360Dialog.ApiClient.Payloads.Enums
{
    [JsonConverter(typeof(InteractiveReplyTypeConverter))]
    public enum InteractiveReplyType
    {
        button_reply = 1,
        list_reply = 2
    }
}