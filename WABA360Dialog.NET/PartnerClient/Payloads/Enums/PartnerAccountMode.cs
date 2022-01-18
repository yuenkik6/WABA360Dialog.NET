using Newtonsoft.Json;
using WABA360Dialog.PartnerClient.Converters;

namespace WABA360Dialog.PartnerClient.Payloads.Enums
{
    [JsonConverter(typeof(PartnerAccountModeConverter))]
    public enum PartnerAccountMode
    {
        unknown = 0,
        sandbox = 1,
        live = 2,
    }
}