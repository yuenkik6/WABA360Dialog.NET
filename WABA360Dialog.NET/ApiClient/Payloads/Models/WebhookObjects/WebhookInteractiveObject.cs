using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Enums;

namespace WABA360Dialog.ApiClient.Payloads.Models.WebhookObjects
{
    public class WebhookInteractiveReplyObject
    {
        /// <summary>
        /// button_reply, list_reply
        /// </summary>
        [JsonProperty("type")]
        public InteractiveReplyType Type { get; set; }

        /// <summary>
        /// Used to notify you when customers are replying to Quick Reply Messages.
        /// </summary>
        [JsonProperty("button_reply")]
        public WebhookButtonReplyObject ButtonReply { get; set; }

        /// <summary>
        /// Used to notify you when customers are replying to List Messages.
        /// </summary>
        [JsonProperty("list_reply")]
        public WebhookListReplyObject ListReply { get; set; }
    }
}