using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using WABA360Dialog.PartnerClient.Payloads.Base;
using WABA360Dialog.PartnerClient.Payloads.Models;

namespace WABA360Dialog.PartnerClient.Payloads
{
    public class GetClientBalanceRequest : PartnerApiRequestBase<GetClientBalanceResponse>
    {
        public GetClientBalanceRequest(string partnerId, string clientId, int fromMonth, int fromYear) : base($"partners/{partnerId}/clients/{clientId}/info/balance", HttpMethod.Get)
        {
            PartnerId = partnerId;
            ClientId = clientId;
            QueryParams = new Dictionary<string, string>
            {
                ["from_month"] = fromMonth.ToString(),
                ["from_year"] = fromYear.ToString(),
            };
        }

        [JsonIgnore]
        public string PartnerId { get; }
        
        [JsonIgnore]
        public string ClientId { get; }
        
        [JsonIgnore]
        public int FromMonth { get; }
        
        [JsonIgnore]
        public int FromYear { get; }
    }
    
    public class GetClientBalanceResponse : PartnerApiResponseBase
    {
        [JsonProperty("balance")]
        public decimal Balance { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("last_renewal")]
        public LastRenewal LastRenewal { get; set; }

        [JsonProperty("estimated_template_cost")]
        public decimal EstimatedTemplateCost { get; set; }

        [JsonProperty("bi_price_for_currency_and_client_country")]
        public decimal BiPriceForCurrencyAndClientCountry { get; set; }

        [JsonProperty("ui_price_for_currency_and_client_country")]
        public decimal UiPriceForCurrencyAndClientCountry { get; set; }

        [JsonProperty("usage")]
        public IEnumerable<Usage> Usage { get; set; }
    }

}