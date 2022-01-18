using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.WebhookObjects
{
    public class PricingObject
    {
        /// <summary>
        /// Type of pricing model being used. Current supported values are:
        /// "CBP" (conversation-based pricing): See Conversation-Based Pricing for rates based on recipient country.
        /// "NBP" (notification-based pricing): Notifications are also known as Template Messages (more details on pricing here). This pricing model will be deprecated starting February 1st, 2022.
        /// </summary>
        [JsonProperty("pricing_model")]
        public string PricingModel { get; set; }

        /// <summary>
        /// Indicates if the given message or conversation is billable. Value varies according to pricing_model.
        /// - This flag is set to false if the conversation was initiated from free entry points. Conversations initiated from free entry points are not billable.
        /// - For all other conversations, it’s set to true.
        /// - This is also set to true for conversations inside your free tier limit. You will not be charged for these conversations, but they are considered billable and will be reflected on your invoice.
        /// If you are using NBP (notification-based pricing):
        /// - This flag is false for user-initiated conversations.
        /// - This flag is set to true for notification messages (template messages)
        /// </summary>
        [JsonProperty("billable")]
        public bool Billable { get; set; }

        /// <summary>
        /// Indicates the conversation pricing category. Currently, available options are:
        /// - business_initiated: indicates that the conversation started by a business sending the first message to a user. This applies any time it has been more than 24 hours since the last user message.
        /// - user_initiated: indicates that the conversation started by a business replying to a user message. This applies only when the business reply is within 24 hours of the last user message.
        /// - referral_conversion: indicates that the conversation originated from a free entry point. These conversations are always user-initiated.
        /// </summary>
        [JsonProperty("category")]
        public bool Category { get; set; }
    }
}