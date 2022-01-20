using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Enums;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.ContactObjects;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.HsmObjects;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.InteractiveObjects;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.LocationObjects;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.MediaObjects;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.TemplateObjects;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.TextObjects;

namespace WABA360Dialog.ApiClient.Payloads.Models.MessageObjects
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class MessageObject
    {
        /// <summary>
        /// Optional.
        /// The type of recipient the message is being sent to.
        /// Supported value: individual
        /// </summary>
        [JsonProperty("recipient_type")]
        public string RecipientType { get; set; }

        /// <summary>
        /// Required.
        /// The WhatsApp ID for the recipient of your message. Use the ID returned from the contacts endpoint.
        /// </summary>
        [JsonProperty("to")]
        public string To { get; set; }

        /// <summary>
        /// Optional for text messages. Required for all other message types.
        /// The type of message you would like to send.
        /// Supported values:
        /// audio - Used in media messages.
        /// contact - Used in contact messages.
        /// document - Used in media messages.
        /// image - Used in media messages.
        /// location - Used in location messages.
        /// sticker - Used in media messages.
        /// template - Used to create message templates.
        /// text - Default. Used on text messages.
        /// video - Used in media messages.
        /// interactive - Used in interactive messages.
        /// hsm - This option will be deprecated when we launch the WhatsApp Business API v2.39. Use template instead.
        /// </summary>
        [JsonProperty("type")]
        public MessageType Type { get; set; }

        /// <summary>
        /// Only used with messages of text type.
        /// Allows for URL previews in text messages. For more information, see the Sending URLs in Text Messages.
        /// This field is optional if not including a URL in your message.
        /// Values: false (default), true
        /// </summary>
        [JsonProperty("preview_url")]
        public bool? PreviewUrl { get; set; }

        /// <summary>
        /// Required for messages of text type.
        /// Contains a text object.
        /// </summary>
        [JsonProperty("text")]
        public TextObject Text { get; set; }

        /// <summary>
        /// Required when type is set to audio.
        /// The media object containing audio.
        /// </summary>
        [JsonProperty("audio")]
        public MediaObject Audio { get; set; }

        /// <summary>
        /// Required when type is set to document.
        /// The media object containing a document.
        /// </summary>
        [JsonProperty("document")]
        public MediaObject Document { get; set; }

        /// <summary>
        /// Required when type is set to image.
        /// The media object containing an image.
        /// </summary>
        [JsonProperty("image")]
        public MediaObject Image { get; set; }

        /// <summary>
        /// Required when type is set to sticker.
        /// The media object containing a sticker.
        /// </summary>
        [JsonProperty("sticker")]
        public MediaObject Sticker { get; set; }

        /// <summary>
        /// Required when type is set to video.
        /// The media object containing a video.
        /// </summary>
        [JsonProperty("video")]
        public MediaObject Video { get; set; }

        /// <summary>
        /// Required when type is set to contacts.
        /// Contains a contacts object.
        /// </summary>
        [JsonProperty("contacts")]
        public ContactObject Contacts { get; set; }

        /// <summary>
        /// Required when type is set to location.
        /// Contains a location object.
        /// </summary>
        [JsonProperty("location")]
        public LocationObject Location { get; set; }

        /// <summary>
        /// Only used with message templates.
        /// Contains a template object.
        /// </summary>
        [JsonProperty("template")]
        public TemplateMessageObject Template { get; set; }

        /// <summary>
        /// Only used with message templates.
        /// Contains an hsm object. This option will be deprecated when we launch the WhatsApp Business API v2.39. Use the template object instead.
        /// </summary>
        [JsonProperty("hsm")]
        public HsmObject Hsm { get; set; }

        /// <summary>
        /// Required for interactive messages.
        /// This object contains information about the message you would like to send.
        /// The components of each interactive object generally follow a consistent pattern: header, body, footer, and action. See the interactive object below for more information.
        /// </summary>
        [JsonProperty("interactive")]
        public InteractiveObject Interactive { get; set; }
    }
}