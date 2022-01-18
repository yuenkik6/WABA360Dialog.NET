using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.InteractiveObjects
{
    public class TextBodyObject
    {
        /// <summary>
        /// Required.
        /// The body content of the message. Emojis and markdown are supported. Links are supported.
        /// Maximum length: 1024 characters.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}