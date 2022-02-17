using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using WABA360Dialog.PartnerClient.Payloads.Base;
using WABA360Dialog.PartnerClient.Payloads.Models;

namespace WABA360Dialog.PartnerClient.Payloads
{
    public class GetApiKeyByChannelRequest : PartnerApiRequestBase<GetApiKeyByChannelResponse>
    {
        public GetApiKeyByChannelRequest(string partnerId, string channelId)
            : base($"partners/{partnerId}/channels/{channelId}/api_keys", HttpMethod.Get)
        {
            PartnerId = partnerId;
            ChannelId = channelId;
        }

        [JsonIgnore]
        public string PartnerId { get; }

        [JsonIgnore]
        public string ChannelId { get; }
    }

    public class GetApiKeyByChannelResponse : PartnerApiResponseBase
    {
        [JsonProperty("api_keys")]
        public IEnumerable<ChannelApiKey> ApiKeys { get; set; }
    }
}