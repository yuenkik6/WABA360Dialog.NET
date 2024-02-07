using System.Collections.Generic;
using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Enums;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.InteractiveObjects;

namespace WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.TemplateObjects
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class TemplateMessageObject
    {
        /// <summary>
        /// Required.
        /// Namespace of the template.
        /// OnPrem: Optional since WABA v2.41
        /// Cloud: not used
        /// </summary>
        [JsonProperty("namespace")]
        public string Namespace { get; set; }

        /// <summary>
        /// Required.
        /// Name of the template.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Required.
        /// Contains a language object. Specifies the language the template may be rendered in.
        /// Only the deterministic language policy works with media template messages.
        /// </summary>
        [JsonProperty("language")]
        public LanguageObject Language { get; set; }

        /// <summary>
        /// Optional.
        /// Array of components objects containing the parameters of the message.
        /// </summary>
        [JsonProperty("components")]
        public IEnumerable<TemplateMessageComponentObject> Components { get; set; }
    }
}