using Newtonsoft.Json;
using System.Collections.Generic;

namespace WABA360Dialog.Cloud.ApiClient.Payloads.Models.WebhookObjects
{
    public class WebhookNotificationEntry
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("changes")]
        public IEnumerable<WebhookNotificationEntryChange> Changes { get; set; } = new List<WebhookNotificationEntryChange>();
    }
}