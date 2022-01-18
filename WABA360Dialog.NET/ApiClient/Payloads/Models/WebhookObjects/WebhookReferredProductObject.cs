using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.WebhookObjects
{
    public class WebhookReferredProductObject
    {
        [JsonProperty("catalog_id")]
        public string CatalogId { get; set; }

        [JsonProperty("product_retailer_id")]
        public string ProductRetailerId { get; set; }
    }
}