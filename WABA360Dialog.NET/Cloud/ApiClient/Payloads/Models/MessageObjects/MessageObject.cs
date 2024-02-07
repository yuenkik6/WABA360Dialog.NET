using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Base.Models;
using WABA360Dialog.Cloud.ApiClient.Payloads.Enums;

namespace WABA360Dialog.Cloud.ApiClient.Payloads.Models.MessageObjects
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class MessageObject : AbstractMessageObject
    {
        public MessageObject()
        {
            RecipientType = "individual";
        }

        [JsonProperty("messaging_product")]
        public MessagingProduct MessagingProduct { get; set; } = MessagingProduct.whatsapp;
    }
}