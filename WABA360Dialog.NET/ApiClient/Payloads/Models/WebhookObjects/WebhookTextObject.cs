using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.WebhookObjects
{
    public class WebhookTextObject
    {
        /// <summary>
        /// Message text
        /// </summary>
        [JsonProperty("body")]
        public string Body { get; set; }
    }
}