using System.Collections.Generic;
using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Models.Common;
using WABA360Dialog.ApiClient.Payloads.Models.WebhookObjects;

namespace WABA360Dialog.ApiClient.Payloads.Models
{
    public class WABA360DialogWebhookPayload
    {
        /// <summary>
        /// Provides all the information about the contact —see contacts object.
        /// This object only applies to text, contacts, and location messages.
        /// It is not currently supported for media messages and is not applicable for system messages.
        /// </summary>
        [JsonProperty("contacts")]
        public IEnumerable<WebhookContactObject> Contacts { get; set; }

        /// <summary>
        /// Webhook notifications of received messages are contained within a messages object.
        /// </summary>
        [JsonProperty("messages")]
        public IEnumerable<WebhookMessageObject> Messages { get; set; }

        /// <summary>
        /// The statuses object keeps you apprised of the status of messages between you and users or groups.
        /// </summary>
        [JsonProperty("statuses")]
        public IEnumerable<WebhookMessageStatus> Statuses { get; set; }

        /// <summary>
        /// When there are any out-of-band errors that occur in the normal operation of the application, the errors array provides a description of the error.
        /// </summary>
        [JsonProperty("errors")]
        public IEnumerable<ErrorObject> Errors { get; set; }
    }


}