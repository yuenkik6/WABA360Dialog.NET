using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.TextObjects
{
    public class TextObject
    {
        /// <summary>
        /// Required.
        /// Contains the text of the message, which can contain URLs and formatting.
        /// </summary>
        [JsonProperty("body")]
        public string Body { get; set; }
    }
}