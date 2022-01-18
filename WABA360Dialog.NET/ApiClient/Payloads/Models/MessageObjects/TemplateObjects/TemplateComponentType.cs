using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Models.Converters;

namespace WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.TemplateObjects
{
    [JsonConverter(typeof(TemplateComponentTypeConverter))]
    public enum TemplateComponentType
    {
        BODY,
        HEADER,
        FOOTER,
        BUTTONS
    }
}