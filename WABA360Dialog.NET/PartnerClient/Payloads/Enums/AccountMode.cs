using Newtonsoft.Json;
using WABA360Dialog.PartnerClient.Converters;

namespace WABA360Dialog.PartnerClient.Payloads.Enums
{
    [JsonConverter(typeof(AccountModeConverter))]
    public enum AccountMode
    {
        sandbox = 1,
        live = 2,
    }
}