using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using WABA360Dialog.PartnerClient.Payloads.Base;

namespace WABA360Dialog.PartnerClient.Payloads
{
    public class DeleteApiKeyByChannelRequest : PartnerApiRequestBase<DeleteApiKeyByChannelResponse>
    {
        public DeleteApiKeyByChannelRequest(string partnerId, string channelId)
            : base($"partners/{partnerId}/channels/{channelId}/api_keys", HttpMethod.Delete)
        {
            PartnerId = partnerId;
            ChannelId = channelId;
        }

        [JsonIgnore]
        public string PartnerId { get; }

        [JsonIgnore]
        public string ChannelId { get; }
    }

    public class DeleteApiKeyByChannelResponse : PartnerApiResponseBase
    {
    }
}
