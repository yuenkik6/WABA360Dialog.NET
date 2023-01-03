using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.WebhookObjects
{
    public class ProfileObject
    {
        /// <summary>
        /// Optional.
        /// Contains the sender's profile name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}