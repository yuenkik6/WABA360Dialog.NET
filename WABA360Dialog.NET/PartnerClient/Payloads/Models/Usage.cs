using System;
using Newtonsoft.Json;

namespace WABA360Dialog.PartnerClient.Payloads.Models
{
    public class Usage
    {
        [JsonProperty("period_date")]
        public DateTime PeriodDate { get; set; }

        [JsonProperty("total_price")]
        public decimal TotalPrice { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}