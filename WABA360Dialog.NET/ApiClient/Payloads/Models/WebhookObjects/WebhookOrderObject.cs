using System.Collections.Generic;
using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.WebhookObjects
{
    public class WebhookOrderObject
    {
        [JsonProperty("catalog_id")]
        public string CatalogId { get; set; }

        [JsonProperty("product_items")]
        public IEnumerable<WebhookProductItemsObject> ProductItems { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}