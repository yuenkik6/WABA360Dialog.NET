using System.Collections.Generic;
using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.WebhookObjects
{
    public class WebhookContextObject
    {
        /// <summary>
        /// Optional. Will not be present if the user only interacts with the message.
        /// WhatsApp ID of the sender of the original message.
        /// </summary>
        [JsonProperty("from")]
        public string From { get; set; }

        /// <summary>
        /// Optional. Will not be present if the user only interacts with the message.
        /// Message ID of original message.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Used for enquiries coming from a Product Detail Page, Single Product Messages, and Multi-Product Message.
        /// </summary>
        [JsonProperty("referred_product")]
        public WebhookReferredProductObject ReferredProduct { get; set; }

        [JsonProperty("mentions")]
        public IEnumerable<string> Mentions { get; set; }
        
        [JsonProperty("forwarded")]
        public bool? Forwarded { get; set; }
        
        [JsonProperty("frequently_forwarded")]
        public bool? FrequentlyForwarded { get; set; }
    }
}