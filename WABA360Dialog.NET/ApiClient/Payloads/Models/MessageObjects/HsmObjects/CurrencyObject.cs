using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.HsmObjects
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CurrencyObject
    {
        /// <summary>
        /// Required.
        /// Currency code as defined in ISO 4217.
        /// </summary>
        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Required.
        /// Amount multiplied by 1000.
        /// </summary>
        [JsonProperty("amount_1000")]
        public int Amount1000 { get; set; }
    }
}