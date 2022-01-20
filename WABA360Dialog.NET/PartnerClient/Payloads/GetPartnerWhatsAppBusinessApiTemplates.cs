using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using WABA360Dialog.Common.Helpers;
using WABA360Dialog.PartnerClient.Payloads.Base;
using WABA360Dialog.PartnerClient.Payloads.Enums;
using WABA360Dialog.PartnerClient.Payloads.Models;

namespace WABA360Dialog.PartnerClient.Payloads
{
    public class GetPartnerWhatsAppBusinessApiTemplatesRequest : PartnerApiRequestBase<GetPartnerWhatsAppBusinessApiTemplatesResponse>
    {
        public GetPartnerWhatsAppBusinessApiTemplatesRequest(string partnerId, string whatsAppBusinessApiAccountId, int limit = 20, int offset = 0, string sort = "-", GetPartnerWhatsAppBusinessApiTemplatesFilter filters = null)
            : base($"partners/{partnerId}/waba_accounts/{whatsAppBusinessApiAccountId}/waba_templates", HttpMethod.Get)
        {
            PartnerId = partnerId;
            WhatsAppBusinessApiAccountId = whatsAppBusinessApiAccountId;
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
        public string WhatsAppBusinessApiAccountId { get; }

        [JsonIgnore]
        public int Limit { get; }

        [JsonIgnore]
        public int Offset { get; }

        [JsonIgnore]
        public string Sort { get; }

        [JsonIgnore]
        public GetPartnerWhatsAppBusinessApiTemplatesFilter Filters { get; set; }
    }
    
    
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class GetPartnerWhatsAppBusinessApiTemplatesFilter
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("partner_id")]
        public string PartnerId { get; set; }

        [JsonProperty("waba_account_id")]
        public string WhatsAppBusinessApiAccountId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public TemplateStatus Status { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("rejected_reason")]
        public string RejectedReason { get; set; }

        [JsonProperty("namespace")]
        public string Namespace { get; set; }
    }

    public class GetPartnerWhatsAppBusinessApiTemplatesResponse : PartnerApiResponseBase
    {

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("sort")]
        public IEnumerable<string> Sort { get; set; }

        [JsonProperty("filters")]
        public object Filters { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("waba_templates")]
        public IEnumerable<PartnerWhatsAppBusinessApiTemplate> WhatsAppBusinessApiTemplates { get; set; }
    }

}