using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.WebhookObjects
{
    public class WebhookReferralObject
    {
        /// <summary>
        /// Headline used in the ad that generated the message.
        /// </summary>
        [JsonProperty("headline")]
        public string Headline { get; set; }

        /// <summary>
        /// Body from the ad that generated the message.
        /// </summary>
        [JsonProperty("body")]
        public string Body { get; set; }

        /// <summary>
        /// The type of the ad’s source. Currently, supported values are ad and post.
        /// </summary>
        [JsonProperty("source_type")]
        public string SourceType { get; set; }

        /// <summary>
        /// Facebook ID for an ad or a post.
        /// </summary>
        [JsonProperty("source_id")]
        public string SourceId { get; set; }

        /// <summary>
        /// The url that leads to the ad or post. Opening this url takes you to the ad viewed by your user.
        /// In some cases, a referral object may contain only the source_url field. This is expected and happens due to:
        /// A user sending the message before the context for the ad or post has been rendered on the user’s app.
        /// An error or mismatch when the user's client tries to look for an ad or post’s context.
        /// </summary>
        [JsonProperty("source_url")]
        public string SourceUrl { get; set; }

        /// <summary>
        /// Optional.
        /// The video that the user saw and clicked. This object is missing if the skip_referral_media_download application setting is set to true. See application settings for more details.
        /// </summary>
        [JsonProperty("video")]
        public WebhookMediaObject Video { get; set; }

        /// <summary>
        /// Optional.
        /// The image that the user saw and clicked. This object is missing if the skip_referral_media_download application setting is set to true. See application settings for more details.
        /// </summary>
        [JsonProperty("image")]
        public WebhookMediaObject Image { get; set; }
    }
}