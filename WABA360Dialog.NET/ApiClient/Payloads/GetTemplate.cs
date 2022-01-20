using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Base;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.TemplateObjects;

namespace WABA360Dialog.ApiClient.Payloads
{
    public class GetTemplateRequest : ClientApiRequestBase<GetTemplateResponse>
    {
        public GetTemplateRequest(int limit = 1000, int offset = 0, string sort = null) : base("v1/configs/templates", HttpMethod.Get)
        {
            Limit = limit;
            Offset = offset;
            Sort = sort;

            QueryParams = new Dictionary<string, string>
            {
                ["limit"] = limit.ToString(),
                ["offset"] = offset.ToString(),
                ["sort"] = sort
            };
        }

        [JsonIgnore]
        public int Limit { get; }

        [JsonIgnore]
        public int Offset { get; }

        [JsonIgnore]
        public string Sort { get; }
    }

    public class GetTemplateResponse : ClientApiResponseBase
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

        [JsonProperty("waba_templates")]
        public IEnumerable<WhatsAppBusinessApiTemplate> WhatsAppBusinessApiTemplates { get; set; }
    }

}