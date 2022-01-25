using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Converters;

namespace WABA360Dialog.ApiClient.Payloads.Enums
{
    [JsonConverter(typeof(TemplateComponentTypeConverter))]
    public enum TemplateComponentType
    {
        BODY = 1,
        HEADER = 2,
        FOOTER = 3,
        BUTTONS = 4,
    }
}