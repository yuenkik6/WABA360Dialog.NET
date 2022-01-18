using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Enums;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.MediaObjects;

namespace WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.InteractiveObjects
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class HeaderObject
    {
        /// <summary>
        /// Required.
        /// The header type you would like to use. Supported values are:
        /// text: Used for List Messages, Reply Buttons, and Multi-Product Messages.
        /// video: Used for Reply Buttons.
        /// image: Used for Reply Buttons.
        /// document: Used for Reply Buttons.
        /// </summary>
        [JsonProperty("type")]
        public HeaderType Type { get; set; }

        /// <summary>
        /// Required if type is set to text.
        /// Text for the header. Formatting allows emojis, but not markdown.
        /// Maximum length: 60 characters.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Required if type is set to video.
        /// Contains the media object for this video.
        /// </summary>
        [JsonProperty("video")]
        public MediaObject Video { get; set; }

        /// <summary>
        /// Required if type is set to image.
        /// Contains the media object for this image.
        /// </summary>
        [JsonProperty("image")]
        public MediaObject Image { get; set; }

        /// <summary>
        /// Required if type is set to document.
        /// Contains the media object for this document.
        /// </summary>
        [JsonProperty("document")]
        public MediaObject Document { get; set; }
    }


}
