using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Enums;

namespace WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.HsmObjects
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class HsmObject
    {
        /// <summary>
        /// Required.
        /// The namespace to be used. Beginning with v2.2.7, if the namespace does not match up to the element_name, the message fails to send.
        /// </summary>
        [JsonProperty("namespace")]
        public string Namespace { get; set; }

        /// <summary>
        /// Required.
        /// The element name that indicates which template to use within the namespace. Beginning with v2.2.7, if the element_name does not match up to the namespace, the message fails to send.
        /// </summary>
        [JsonProperty("element_name")]
        public string ElementName { get; set; }

        /// <summary>
        /// Required.
        /// Allows for the specification of a deterministic language. See the Language section for more information.
        /// This field used to allow for a fallback option, but this has been deprecated with v2.27.8.
        /// </summary>
        [JsonProperty("language")]
        public LanguageObject Language { get; set; }

        /// <summary>
        /// Required.
        /// This field is an array of values to apply to variables in the template. See the Localizable Parameters section for more information.
        /// </summary>
        [JsonProperty("localizable_params")]
        public LocalizableParamObject LocalizableParams { get; set; }
    }
}