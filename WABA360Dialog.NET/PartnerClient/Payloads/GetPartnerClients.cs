using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using WABA360Dialog.Common.Helpers;
using WABA360Dialog.PartnerClient.Payloads.Base;
using WABA360Dialog.PartnerClient.Payloads.Enums;
using WABA360Dialog.PartnerClient.Payloads.Models;

namespace WABA360Dialog.PartnerClient.Payloads
{
    public class GetPartnerClientsRequest : PartnerApiRequestBase<GetPartnerClientsResponse>
    {
        public GetPartnerClientsRequest(string partnerId, int limit = 20, int offset = 0, string sort = "-", GetPartnerClientsFilter filters = null) : base($"partners/{partnerId}/clients", HttpMethod.Get)
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
        public GetPartnerClientsFilter Filters { get; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class GetPartnerClientsFilter
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public ClientStatus Status { get; set; }

        [JsonProperty("organisation")]
        public string Organisation { get; set; }
    }

    public class GetPartnerClientsResponse : PartnerApiResponseBase
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

        [JsonProperty("clients")]
        public IEnumerable<WhatsAppBusinessApiClient> Clients { get; set; }
    }

}