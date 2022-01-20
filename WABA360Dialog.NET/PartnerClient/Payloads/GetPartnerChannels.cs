using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using WABA360Dialog.Common.Helpers;
using WABA360Dialog.PartnerClient.Payloads.Base;
using WABA360Dialog.PartnerClient.Payloads.Enums;
using WABA360Dialog.PartnerClient.Payloads.Models;

namespace WABA360Dialog.PartnerClient.Payloads
{
    public class GetPartnerChannelsRequest : PartnerApiRequestBase<GetPartnerChannelsResponse>
    {
        public GetPartnerChannelsRequest(string partnerId, int limit = 20, int offset = 0, string sort = "-", GetPartnerChannelsFilter filters = null) : base($"partners/{partnerId}/channels", HttpMethod.Get)
        {
            PartnerId = partnerId;
            Limit = limit;
            Offset = offset;
            Sort = sort;
            Filters = filters;

            QueryParams = new Dictionary<string, string>
            {
                ["limit"] = limit.ToString(),
                ["offset"] = offset.ToString(),
                ["sort"] = sort,
                ["filters"] = JsonHelper.SerializeObjectToJson(filters)
            };
        }

        [JsonIgnore]
        public string PartnerId { get; }

        [JsonIgnore]
        public int Limit { get; }

        [JsonIgnore]
        public int Offset { get; }

        [JsonIgnore]
        public string Sort { get; }

        [JsonIgnore]
        public GetPartnerChannelsFilter Filters { get; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class GetPartnerChannelsFilter
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("account_mode")]
        public AccountMode AccountMode { get; set; }

        [JsonProperty("status")]
        public PartnerChannelStatus Status { get; set; }
    }

    
    public class GetPartnerChannelsResponse : PartnerApiResponseBase
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("filters")]
        public object Filters { get; set; }

        [JsonProperty("sort")]
        public IEnumerable<string> Sort { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("partner_channels")]
        public IEnumerable<PartnerChannel> PartnerChannels { get; set; }

    }

}