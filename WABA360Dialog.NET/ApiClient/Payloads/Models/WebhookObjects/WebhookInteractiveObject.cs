using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.WebhookObjects
{
    public class WebhookInteractiveObject
    {
        /// <summary>
        /// button_reply, list_reply
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("button_reply")]
        public WebhookButtonReplyObject ButtonReply { get; set; }

        [JsonProperty("list_reply")]
        public WebhookButtonReplyObject ListReply { get; set; }
    }
}