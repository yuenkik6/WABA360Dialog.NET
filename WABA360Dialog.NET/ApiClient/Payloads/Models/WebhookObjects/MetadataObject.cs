using System.Collections.Generic;
using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.WebhookObjects
{
    public class MetadataObject
    {
        [JsonProperty("android-app-store-link")]
        public string AndroidAppStoreLink { get; set; }

        [JsonProperty("emojis")]
        public IEnumerable<string> Emojis { get; set; }

        [JsonProperty("ios-app-store-link")]
        public string IosAppStoreLink { get; set; }

        [JsonProperty("is-first-party-sticker")]
        public int IsFirstPartySticker { get; set; }

        [JsonProperty("sticker-pack-id")]
        public string StickerPackId { get; set; }

        [JsonProperty("sticker-pack-name")]
        public string StickerPackName { get; set; }

        [JsonProperty("sticker-pack-publisher")]
        public string StickerPackPublisher { get; set; }
    }
}