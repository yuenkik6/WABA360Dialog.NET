using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Enums;

namespace WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.ContactObjects
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ImsObject
    {
        [JsonProperty("service")]
        public string Service { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }
    }
}