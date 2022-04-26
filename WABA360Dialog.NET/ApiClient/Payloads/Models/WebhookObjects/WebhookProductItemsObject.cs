using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.WebhookObjects
{
    public class WebhookProductItemsObject
    {
        /// <summary>
        /// Unique identifier (in the catalog) of the product.
        /// </summary>
        [JsonProperty("product_retailer_id")]
        public string ProductRetailerId { get; set; }

        /// <summary>
        /// Number of items purchased.
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Unitary price of the items.
        /// </summary>
        [JsonProperty("item_price")]
        public decimal ItemPrice { get; set; }

        /// <summary>
        /// Currency of the price.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}