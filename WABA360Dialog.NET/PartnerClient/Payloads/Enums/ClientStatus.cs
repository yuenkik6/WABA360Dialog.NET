using Newtonsoft.Json;

namespace WABA360Dialog.PartnerClient.Payloads.Enums
{
    [JsonConverter(typeof(ClientStatusConverter))]
    public enum ClientStatus
    {
        unknown = 0,
        active = 1,
    }
}