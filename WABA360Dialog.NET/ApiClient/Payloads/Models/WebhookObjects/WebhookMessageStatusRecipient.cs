using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.WebhookObjects
{
    public class WebhookMessageStatusRecipient
    {
        /// <summary>
        /// WhatsApp ID of recipient
        /// </summary>
        [JsonProperty("recipient_id")]
        public string RecipientId { get; set; }
    }
}