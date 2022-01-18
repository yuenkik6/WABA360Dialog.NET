using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.HsmObjects
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class LocalizableParamObject
    {
        /// <summary>
        /// Required.
        /// The code of the language or locale to use. Accepts both language and language_locale formats (e.g., en and en_US).
        /// See Supported Languages for all codes.
        /// </summary>
        [JsonProperty("default")]
        public string Default { get; set; }

        /// <summary>
        /// Optional.
        /// If the currency object is used, it contains required parameters currency_code and amount_1000.
        /// </summary>
        [JsonProperty("currency")]
        public CurrencyObject Currency { get; set; }

        /// <summary>
        /// Optional.
        /// If the date_time object is used, further definition of the date and time is required. See the example below for two of the options.
        /// </summary>
        [JsonProperty("date_time")]
        public DateTimeObject DateTime { get; set; }
    }
}