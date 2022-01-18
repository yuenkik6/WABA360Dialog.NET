using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Models.Converters;

namespace WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.TemplateObjects
{
    [JsonConverter(typeof(TemplateButtonTypeConverter))]
    public enum TemplateButtonType
    {
        PHONE_NUMBER,
        URL,
        QUICK_REPLY
    }
}