using Newtonsoft.Json;
using System.Collections.Generic;
using WABA360Dialog.Cloud.ApiClient.Payloads.Enums;

namespace WABA360Dialog.Cloud.ApiClient.Payloads.Responses
{
    public class SendMessageResponse : WABA360Dialog.ApiClient.Payloads.Base.ClientApiResponseBase
    {
        [JsonProperty("contacts")]
        public IEnumerable<WABA360Dialog.ApiClient.Payloads.Models.SendMessageContactResult> Contacts { get; set; }

        [JsonProperty("messages")]
        public IEnumerable<WABA360Dialog.ApiClient.Payloads.Models.SendMessageResult> CreatedMessages { get; set; }

        [JsonProperty("messaging_product")]
        public MessagingProduct MessagingProduct { get; set; }
    }
}