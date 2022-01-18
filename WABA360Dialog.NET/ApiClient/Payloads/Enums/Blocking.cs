using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Converters;

namespace WABA360Dialog.ApiClient.Payloads.Enums
{
    [JsonConverter(typeof(BlockingConverter))]
    public enum Blocking
    {
        no_wait = 0,
        wait = 1
    }
}