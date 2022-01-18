using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.WebhookObjects
{
    public class WebhookTextObject
    {
        /// <summary>
        /// Required.
        /// Contains the text of the message, which can contain URLs and formatting.
        /// </summary>
        [JsonProperty("body")]
        public string Body { get; set; }
    }
}