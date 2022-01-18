using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.WebhookObjects
{
    public class OriginObject
    {
        /// <summary>
        /// Indicates where a conversation has started. This can also be referred to as a conversation entry point. Currently, the available options are:
        /// business_initiated: indicates that the conversation started by a business sending the first message to a user. This applies any time it has been more than 24 hours since the last user message.
        /// user_initiated: indicates that the conversation started by a business replying to a user message. This applies only when the business reply is within 24 hours of the last user message.
        /// referral_conversion: indicates that the conversation originated from a free entry point. These conversations are always user-initiated.
        /// We may add more granularity on entry point point type in the origin object in future.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}