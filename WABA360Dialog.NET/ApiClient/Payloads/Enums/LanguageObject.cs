using Newtonsoft.Json;
using WABA360Dialog.Common.Enums;

namespace WABA360Dialog.ApiClient.Payloads.Enums
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class LanguageObject
    {
        /// <summary>
        /// Required.
        /// The code of the language or locale to use. Accepts both language and language_locale formats (e.g., en and en_US).
        /// See WhatsAppLanguage for all codes.
        /// </summary>
        [JsonProperty("code")]
        public WhatsAppLanguage Code { get; set; }

        /// <summary>
        /// Required.
        /// Default (and only supported option): deterministic
        /// The language policy the message should follow. See Language Policy Options for more information.
        /// </summary>
        [JsonProperty("policy")]
        public string Policy { get; set; }
    }
}