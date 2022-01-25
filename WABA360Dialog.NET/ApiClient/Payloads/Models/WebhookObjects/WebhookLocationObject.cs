using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.WebhookObjects
{
    public class WebhookLocationObject
    {
        /// <summary>
        /// Required.
        /// Longitude of the location.
        /// </summary>
        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        /// <summary>
        /// Required.
        /// Latitude of the location.
        /// </summary>
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        /// <summary>
        /// Optional.
        /// Name of the location.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Optional.
        /// Address of the location. Only displayed if name is present.
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }
        
        /// <summary>
        /// Optional.
        /// Url of the location.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}