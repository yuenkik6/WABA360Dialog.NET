using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.WebhookObjects
{
    public class WebhookTemplateButtonReplyObject
    {
        /// <summary>
        /// Payload of replying to Template Message
        /// </summary>
        [JsonProperty("payload")]
        public string Payload { get; set; }
        
        /// <summary>
        /// Text of replying to Template Message
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}