using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.WebhookObjects
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class WebhookMediaObject
    {
        /// <summary>
        /// Required when type is audio, document, image, sticker, or video and you are not using a link.
        /// The media object ID. Do not use this field when message type is set to text.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

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
        /// Metadata pertaining to sticker media.
        /// </summary>
        [JsonProperty("metadata")]
        public MetadataObject Metadata { get; set; }

        /// <summary>
        /// Mime type of the media.
        /// </summary>
        [JsonProperty("mime_type")]
        public string MimeType { get; set; }

        /// <summary>
        /// Checksum.
        /// </summary>
        [JsonProperty("sha256")]
        public string Sha256 { get; set; }
    }
}