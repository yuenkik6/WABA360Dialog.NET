using Newtonsoft.Json;
using WABA360Dialog.PartnerClient.Converters;

namespace WABA360Dialog.PartnerClient.Payloads.Enums
{
    [JsonConverter(typeof(PartnerChannelStatusConverter))]
    public enum PartnerChannelStatus
    {
        unknown = 0,
        created = 1,
        unverified = 2,
        verified = 3,
        ready = 4,
        modified = 5,
        imported = 6,
        new_name_requested = 7,
        certificate_declined = 8,
        consents_signed = 9,
        error = 10,
        porting_ready = 11,
        ready_for_migration = 12,
        waiting_for_migration_code = 13,
        migration_code_requested = 14,
    }

}