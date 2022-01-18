using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.InteractiveObjects
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ProductObject
    {
        /// <summary>
        /// Required for Multi-Product Messages.
        /// Unique identifier of the product in a catalog.
        /// </summary>
        [JsonProperty("product_retailer_id")]
        public string ProductRetailerId { get; set; }
    }
}