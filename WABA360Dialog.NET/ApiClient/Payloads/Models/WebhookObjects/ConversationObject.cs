using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.WebhookObjects
{
    public class ConversationObject
    {
        /// <summary>
        /// Represents the ID of the conversation the given status notification belongs to.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Describes where the conversation originated from. See origin object for more information.
        /// </summary>
        [JsonProperty("origin")]
        public OriginObject Origin { get; set; }
    }
}