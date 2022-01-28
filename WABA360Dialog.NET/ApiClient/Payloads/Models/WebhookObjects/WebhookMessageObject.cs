using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Enums;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.ContactObjects;

namespace WABA360Dialog.ApiClient.Payloads.Models.WebhookObjects
{
    public class WebhookMessageObject
    {
        /// <summary>
        /// Optional.
        /// This object will only be included when someone replies to one of your messages.
        /// Contains information about the content of the original message, such as the ID of the sender and the ID of the message.
        /// See context object for more information.
        /// </summary>
        [JsonProperty("context")]
        public WebhookContextObject Context { get; set; }

        /// <summary>
        /// WhatsApp ID of the sender.
        /// </summary>
        [JsonProperty("from")]
        public string From { get; set; }

        /// <summary>
        /// Message ID.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Optional.
        /// Contains information about the user identity used to decrypt the incoming message. See identity object.
        /// </summary>
        [JsonProperty("identity")]
        public MessageIdentityObject Identity { get; set; }

        /// <summary>
        /// Message received timestamp.
        /// </summary>
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        /// <summary>
        /// Message type.
        /// Supported values are: audio, contacts, document, image, location, text, unknown, video, voice
        /// </summary>
        [JsonProperty("type")]
        public MessageType Type { get; set; }

        [JsonProperty("text")]
        public WebhookTextObject Text { get; set; }

        [JsonProperty("audio")]
        public WebhookMediaObject WebhookAudioObject { get; set; }

        [JsonProperty("document")]
        public WebhookMediaObject WebhookDocumentObject { get; set; }

        [JsonProperty("image")]
        public WebhookMediaObject WebhookImageObject { get; set; }

        [JsonProperty("location")]
        public WebhookMediaObject LocationObject { get; set; }

        [JsonProperty("video")]
        public WebhookMediaObject WebhookVideoObject { get; set; }

        [JsonProperty("voice")]
        public WebhookMediaObject WebhookVoiceObject { get; set; }

        [JsonProperty("system")]
        public WebhookSystemObject WebhookSystemObject { get; set; }

        [JsonProperty("contacts")]
        public ContactObject WebhookContactObject { get; set; }

        [JsonProperty("interactive")]
        public WebhookInteractiveObject Interactive { get; set; }
    }
}