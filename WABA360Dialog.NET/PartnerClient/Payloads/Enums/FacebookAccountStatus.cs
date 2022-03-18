using Newtonsoft.Json;
using WABA360Dialog.PartnerClient.Converters;

namespace WABA360Dialog.PartnerClient.Payloads.Enums
{
    [JsonConverter(typeof(FacebookAccountStatusConverter))]
    public enum FacebookAccountStatus
    {
        unknown = 0,
        verified = 1,
        not_verified = 2,
        rejected = 3,
        pending_submission = 4,
        failed = 5,
        pending = 6,
        pending_need_more_info = 7,
    }
}