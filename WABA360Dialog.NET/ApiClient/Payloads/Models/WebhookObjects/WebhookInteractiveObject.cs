using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Enums;

namespace WABA360Dialog.ApiClient.Payloads.Models.WebhookObjects
{
    public class WebhookInteractiveObject
    {
        /// <summary>
        /// button_reply, list_reply
        /// </summary>
        [JsonProperty("type")]
        public InteractiveReplyType Type { get; set; }

        [JsonProperty("button_reply")]
        public WebhookButtonReplyObject ButtonReply { get; set; }

        [JsonProperty("list_reply")]
        public WebhookReplyListObject ListReply { get; set; }
    }
}