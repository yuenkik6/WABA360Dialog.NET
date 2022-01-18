using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.HsmObjects
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class DateTimeObject
    {
        /// <summary>
        /// Required if unix_epoch is not present.
        /// Date/time by component.
        /// </summary>
        [JsonProperty("component")]
        public HsmDateTimeComponentObject Component { get; set; }

        /// <summary>
        /// Required if component is not present.
        /// Date/time by Unix epoch.
        /// </summary>
        [JsonProperty("unix_epoch")]
        public HsmDateTimeUnixEpochObject UnixEpoch { get; set; }
    }
}