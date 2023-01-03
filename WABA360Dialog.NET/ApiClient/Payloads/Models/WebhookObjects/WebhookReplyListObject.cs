using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.WebhookObjects
{
    public class WebhookListReplyObject
    {
        /// <summary>
        /// Id of replying to List Message
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Title of replying to List Message
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Description of replying to List Message
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}