using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.WebhookObjects
{
    public class WebhookContactObject
    {
        /// <summary>
        /// This object contains the sender's profile information.
        /// </summary>
        [JsonProperty("profile")]
        public ProfileObject Profile { get; set; }

        /// <summary>
        /// The WhatsApp ID of the contact.
        /// </summary>
        [JsonProperty("wa_id")]
        public string WaId { get; set; }
    }
}