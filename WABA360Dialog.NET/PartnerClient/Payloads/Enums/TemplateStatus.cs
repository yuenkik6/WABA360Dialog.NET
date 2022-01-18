using Newtonsoft.Json;
using WABA360Dialog.PartnerClient.Converters;

namespace WABA360Dialog.PartnerClient.Payloads.Enums
{
    [JsonConverter(typeof(TemplateStatusConverter))]
    public enum TemplateStatus
    {
        unknown = 0,
        created = 1,
        submitted = 2,
        pending = 3,
        approved = 4,
        rejected = 5,
    }
}