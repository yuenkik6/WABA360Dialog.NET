using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.WebhookObjects
{
    public class WebhookSystemObject
    {
        [JsonProperty("body")]
        public string Body { get; set; }       
        
        [JsonProperty("new_wa_id")]
        public string NewWaId { get; set; }
                
        [JsonProperty("identity")]
        public string Identity { get; set; }
        
        [JsonProperty("type")]
        public string Type { get; set; }
        
    }
}