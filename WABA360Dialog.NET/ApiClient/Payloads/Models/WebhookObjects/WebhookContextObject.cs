using System.Collections.Generic;
using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.WebhookObjects
{
    public class WebhookContextObject
    {
        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("referred_product")]
        public WebhookReferredProductObject ReferredProduct { get; set; }

        [JsonProperty("mentions")]
        public IEnumerable<string> Mentions { get; set; }
        
        [JsonProperty("forwarded")]
        public bool Forwarded { get; set; }
        
        [JsonProperty("frequently_forwarded")]
        public bool FrequentlyForwarded { get; set; }
    }
}