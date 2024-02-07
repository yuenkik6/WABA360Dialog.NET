using Newtonsoft.Json;
using WABA360Dialog.Cloud.ApiClient.Payloads.Converters;

namespace WABA360Dialog.Cloud.ApiClient.Payloads.Enums
{
    [JsonConverter(typeof(MessagingProductConverter))]
    public enum MessagingProduct
    {
        unknown = 0,
        whatsapp = 1
    }   
}