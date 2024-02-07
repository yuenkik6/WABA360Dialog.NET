using Newtonsoft.Json;
using System.Collections.Generic;

namespace WABA360Dialog.Cloud.ApiClient.Payloads.Models.WebhookObjects
{
    /// <summary>
    /// https://developers.facebook.com/docs/whatsapp/cloud-api/webhooks/payload-examples#user-changed-number-notification
    /// </summary>
    public class WebhookNotification
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("entry")]
        public IEnumerable<WebhookNotificationEntry> Entry { get; set; } = new List<WebhookNotificationEntry>();
    }
}