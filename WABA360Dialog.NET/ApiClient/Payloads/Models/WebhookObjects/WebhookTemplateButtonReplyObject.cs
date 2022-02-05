using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.WebhookObjects
{
    public class WebhookTemplateButtonReplyObject
    {
        [JsonProperty("payload")]
        public string Payload { get; set; }
        
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}