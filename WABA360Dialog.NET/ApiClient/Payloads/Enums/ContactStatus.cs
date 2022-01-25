using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Converters;

namespace WABA360Dialog.ApiClient.Payloads.Enums
{
    [JsonConverter(typeof(ContactStatusConverter))]
    public enum ContactStatus
    {
        processing = 1,
        valid = 2,
        invalid = 3,
        failed = 4,
    }
}