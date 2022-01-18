using Newtonsoft.Json;
using WABA360Dialog.PartnerClient.Converters;

namespace WABA360Dialog.PartnerClient.Payloads.Enums
{
    [JsonConverter(typeof(VerificationMethodConverter))]
    public enum VerificationMethod
    {
        unknown = 0,
        voice = 1,
        sms = 2,
    }
}