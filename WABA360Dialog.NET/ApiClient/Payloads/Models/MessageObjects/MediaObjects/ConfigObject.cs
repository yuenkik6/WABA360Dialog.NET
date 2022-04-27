using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.MediaObjects
{
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