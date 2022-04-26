using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.WebhookObjects
{
    public class WebhookLocationObject
    {
        /// <summary>
        /// Latitude of location being sent.
        /// </summary>
        [JsonProperty("latitude")]
        public double Latitude { get; set; }
        
        /// <summary>
        /// Longitude of location being sent.
        /// </summary>
        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        /// <summary>
        /// Address of the location.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Address of the location.
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }
        
        /// <summary>
        /// URL for the website where the user downloaded the location information.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}