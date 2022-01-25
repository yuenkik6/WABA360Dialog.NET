using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Converters;

namespace WABA360Dialog.ApiClient.Payloads.Enums
{
    [JsonConverter(typeof(TemplateButtonTypeConverter))]
    public enum TemplateButtonType
    {
        PHONE_NUMBER = 1,
        URL = 2,
        QUICK_REPLY = 3,
    }
}