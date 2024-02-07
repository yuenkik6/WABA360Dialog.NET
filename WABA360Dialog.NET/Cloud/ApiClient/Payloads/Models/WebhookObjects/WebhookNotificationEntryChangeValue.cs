using Newtonsoft.Json;
using System.Collections.Generic;
using ONPREM = WABA360Dialog.ApiClient.Payloads.Models;

namespace WABA360Dialog.Cloud.ApiClient.Payloads.Models.WebhookObjects
{
    public class WebhookNotificationEntryChangeValue
    {
        [JsonProperty("messaging_product")]
        public string MessagingProduct { get; set; }

        [JsonProperty("metadata")]
        public WebhookNotificationEntryChangeValueMetaData Metadata { get; set; }

        /// <summary>
        /// Provides all the information about the contact —see contacts object.
        /// This object only applies to text, contacts, and location messages.
        /// It is not currently supported for media messages and is not applicable for system messages.
        /// </summary>
        [JsonProperty("contacts")]
        public IEnumerable<ONPREM.WebhookObjects.WebhookContactObject> Contacts { get; set; }

        /// <summary>
        /// Webhook notifications of received messages are contained within a messages object.
        /// </summary>
        [JsonProperty("messages")]
        public IEnumerable<ONPREM.WebhookObjects.WebhookMessageObject> Messages { get; set; }

        /// <summary>
        /// The statuses object keeps you apprised of the status of messages between you and users or groups.
        /// </summary>
        [JsonProperty("statuses")]
        public IEnumerable<ONPREM.WebhookObjects.WebhookMessageStatus> Statuses { get; set; }

        /// <summary>
        /// When there are any out-of-band errors that occur in the normal operation of the application, the errors array provides a description of the error.
        /// </summary>
        [JsonProperty("errors")]
        public IEnumerable<ONPREM.Common.ErrorObject> Errors { get; set; }
    }
}