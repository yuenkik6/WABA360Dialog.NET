using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.WebhookObjects
{
    public class WebhookReferredProductObject
    {
        /// <summary>
        /// ID for the catalog the item belongs to.
        /// </summary>
        [JsonProperty("catalog_id")]
        public string CatalogId { get; set; }

        /// <summary>
        /// Unique identifier (in the catalog) of the product.
        /// </summary>
        [JsonProperty("product_retailer_id")]
        public string ProductRetailerId { get; set; }
    }
}