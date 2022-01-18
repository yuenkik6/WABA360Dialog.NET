using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.InteractiveObjects
{
    public class ReplyObject
    {
        /// <summary>
        /// Required.
        /// Unique identifier for your button. This ID is returned in the webhook when the button is clicked by the user.
        /// Maximum length: 256 characters.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Required.
        /// Button title. It cannot be an empty string and must be unique within the message. Does not allow emojis or markdown.
        /// Maximum length: 20 characters.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}