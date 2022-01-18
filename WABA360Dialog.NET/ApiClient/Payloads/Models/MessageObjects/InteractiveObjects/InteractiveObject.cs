using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Enums;

namespace WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.InteractiveObjects
{
    /// <summary>
    /// Sending Interactive Messages
    /// https://developers.facebook.com/docs/whatsapp/guides/interactive-messages/
    /// https://developers.facebook.com/docs/whatsapp/api/messages#body-object
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class InteractiveObject
    {
        /// <summary>
        /// Required.
        /// The type of interactive message you want to send. Supported values:
        /// - list: Use it for List Messages.
        /// - button: Use it for Reply Buttons.
        /// - product: Use it for Single Product Messages.
        /// - product_list: Use it for Multi-Product Messages.
        /// </summary>
        [JsonProperty("type")]
        public InteractiveType Type { get; set; }

        /// <summary>
        /// Required for type product_list. Optional for other types.
        /// Header content displayed on top of a message. See header object for more information.
        /// You cannot set a header if your interactive object is of product type.
        /// </summary>
        [JsonProperty("header")]
        public HeaderObject Header { get; set; }

        /// <summary>
        /// Optional for type product. Required for other message types.
        /// The body of the message. Emojis and markdown are supported.
        /// Maximum length: 1024 characters.
        /// </summary>
        [JsonProperty("body")]
        public TextBodyObject Body { get; set; }

        /// <summary>
        /// Optional.
        /// The footer of the message. Emojis and markdown are supported.
        /// Maximum length: 60 characters.
        /// </summary>
        [JsonProperty("footer")]
        public TextFooterObject Footer { get; set; }

        /// <summary>
        /// Required.
        /// Action you want the user to perform after reading the message.
        /// </summary>
        [JsonProperty("action")]
        public ActionObject Action { get; set; }
    }
}