using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.WebhookObjects
{
    public class ConversationObject
    {
        /// <summary>
        /// Represents the ID of the conversation the given status notification belongs to.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Timestamp when the current ongoing conversation expires. This field is only present on "message sent" webhooks.
        /// </summary>
        [JsonProperty("expiration_timestamp")]
        public long ExpirationTimestamp { get; set; }

        /// <summary>
        /// Describes where the conversation originated from. See origin object for more information.
        /// </summary>
        [JsonProperty("origin")]
        public OriginObject Origin { get; set; }
    }
}