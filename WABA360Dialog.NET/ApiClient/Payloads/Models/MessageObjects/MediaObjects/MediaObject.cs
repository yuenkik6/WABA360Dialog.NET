using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.MediaObjects
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class MediaObject
    {
        /// <summary>
        /// Required when type is audio, document, image, sticker, or video and you are not using a link.
        /// The media object ID. Do not use this field when message type is set to text.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Required when type is audio, document, image, sticker, or video and you are not using an uploaded media ID.
        /// The protocol and URL of the media to be sent. Use only with HTTP/HTTPS URLs.
        /// Do not use this field when message type is set to text.
        /// </summary>
        [JsonProperty("link")]
        public string Link { get; set; }

        /// <summary>
        /// Optional.
        /// Describes the specified document, image, or video media.
        /// Do not use with audio or sticker media.
        /// </summary>
        [JsonProperty("caption")]
        public string Caption { get; set; }

        /// <summary>
        /// Optional.
        /// Describes the filename for the specific document. Use only with document media.
        /// </summary>
        [JsonProperty("filename")]
        public string Filename { get; set; }

        /// <summary>
        /// Optional.
        /// This path is optionally used with a link when the HTTP/HTTPS link is not directly accessible and requires additional configurations like a bearer token.
        /// </summary>
        [JsonProperty("provider")]
        public ProviderObject Provider { get; set; }
    }
}