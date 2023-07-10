using System.Net.Http;
using Newtonsoft.Json;
using WABA360Dialog.PartnerClient.Payloads.Base;

namespace WABA360Dialog.PartnerClient.Payloads
{
    public class CreateApiKeyByChannelRequest : PartnerApiRequestBase<CreateApiKeyByChannelResponse>
    {
        public CreateApiKeyByChannelRequest(string partnerId, string channelId)
            : base($"partners/{partnerId}/channels/{channelId}/api_keys", HttpMethod.Post)
        {
            PartnerId = partnerId;
            ChannelId = channelId;
        }

        [JsonIgnore]
        public string PartnerId { get; }

        [JsonIgnore]
        public string ChannelId { get; }
    }

    public class CreateApiKeyByChannelResponse : PartnerApiResponseBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("api_key")]
        public string ApiKey { get; set; }

        [JsonProperty("app_id")]
        public string AppId { get; set; }
    }
}