using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using WABA360Dialog.PartnerClient.Payloads.Base;
using WABA360Dialog.PartnerClient.Payloads.Models;

namespace WABA360Dialog.PartnerClient.Payloads
{
    public class GetClientBalanceRequest : PartnerApiRequestBase<GetClientBalanceResponse>
    {
        public GetClientBalanceRequest(string partnerId, string clientId, long? startDate, long? endDate, string granularity)
            : base($"partners/{partnerId}/clients/{clientId}/info/balance", HttpMethod.Get)
        {
            PartnerId = partnerId;
            ClientId = clientId;

            QueryParams = new Dictionary<string, string>();

            if (startDate.HasValue)
                QueryParams["start_date"] = startDate.ToString();

            if (endDate.HasValue)
                QueryParams["end_date"] = endDate.ToString();

            if (!string.IsNullOrEmpty(granularity))
                QueryParams["granularity"] = granularity;
        }

        [JsonIgnore]
        public string PartnerId { get; }

        [JsonIgnore]
        public string ClientId { get; }
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

        [JsonProperty("granularity")]
        public string Granularity { get; set; }

        [JsonProperty("bi_price_for_currency_and_client_country")]
        public decimal BiPriceForCurrencyAndClientCountry { get; set; }

        [JsonProperty("ui_price_for_currency_and_client_country")]
        public decimal UiPriceForCurrencyAndClientCountry { get; set; }

        [JsonProperty("usage")]
        public IEnumerable<Usage> Usage { get; set; }
    }
}