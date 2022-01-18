using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.HsmObjects
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class HsmDateTimeUnixEpochObject
    {
        /// <summary>
        /// Required.
        /// Epoch timestamp in seconds. This field is planned to be deprecated.
        /// </summary>
        public long Timestamp { get; set; }
    }
}