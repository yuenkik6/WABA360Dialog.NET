using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.MediaObjects
{
    /// <summary>
    /// Media Providers
    /// https://developers.facebook.com/docs/whatsapp/api/settings/media-providers
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ProviderObject
    {
        /// <summary>
        /// Required.
        /// The name for the provider
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Required.
        /// The type of provider
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Required.
        /// The ConfigObject
        /// </summary>
        [JsonProperty("config")]
        public ConfigObject Config { get; set; }
    }
    
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ConfigObject
    {
        [JsonProperty("basic")]
        public BasicAuth Basic { get; set; }
        
        [JsonProperty("bearer")]
        public BearerAuth Bearer { get; set; }
        
        public class BasicAuth
        {
            [JsonProperty("username")]
            public string Username { get; set; }

            [JsonProperty("password")]
            public string Password { get; set; }
        }

        public class BearerAuth
        {
            [JsonProperty("bearer")]
            public string Bearer { get; set; }
        }
    }
}