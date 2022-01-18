using Newtonsoft.Json;
using WABA360Dialog.PartnerClient.Converters;

namespace WABA360Dialog.PartnerClient.Payloads.Enums
{
    [JsonConverter(typeof(BusinessInfoStatusConverter))]
    public enum BusinessInfoStatus
    {
        unknown = 0,
        submitted = 1,
        approved = 2,
        rejected = 3,
        denied = 4,
    }
}