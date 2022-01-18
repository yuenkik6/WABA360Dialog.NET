using System.Collections.Generic;
using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Enums;
using WABA360Dialog.ApiClient.Payloads.Models.Common;

namespace WABA360Dialog.ApiClient.Payloads.Models.WebhookObjects
{
    public class WebhookMessageStatus
    {
        /// <summary>
        /// Message ID
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// WhatsApp ID of recipient
        /// </summary>
        [JsonProperty("recipient_id")]
        public string RecipientId { get; set; }

        /// <summary>
        /// Status of a message.
        /// Values: read, delivered, sent, failed, deleted
        /// </summary>
        [JsonProperty("status")]
        public MessageStatus Status { get; set; }

        /// <summary>
        /// Timestamp of the status message.
        /// </summary>
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        /// <summary>
        /// The type of entity this status object is about. Currently, the only available option is "message".
        /// This object is only available for the On-Premises implementation of the API. Cloud API developers will not receive this field.
        /// </summary>
        [JsonProperty("type")]
        public MessageType Type { get; set; }

        /// <summary>
        /// When there are any out-of-band errors that occur in the normal operation of the application, the errors array provides a description of the error.
        /// </summary>
        [JsonProperty("errors")]
        public IEnumerable<ErrorObject> Errors { get; set; }

        /// <summary>
        /// Object containing conversation attributes, including id. See conversation object for more information.
        /// </summary>
        [JsonProperty("conversation")]
        public ConversationObject Conversation { get; set; }

        /// <summary>
        /// Object containing billing attributes, including pricing_model, billable flag, and category. See pricing object for more information.
        /// </summary>
        [JsonProperty("pricing")]
        public PricingObject Pricing { get; set; }

    }
}