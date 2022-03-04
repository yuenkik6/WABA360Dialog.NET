using System;
using Newtonsoft.Json;

namespace WABA360Dialog.PartnerClient.Payloads.Models
{
    public class Usage
    {
        [JsonProperty("business_initiated_paid_quantity")]
        public int BusinessInitiatedPaidQuantity { get; set; }

        [JsonProperty("business_initiated_price")]
        public decimal BusinessInitiatedPrice { get; set; }

        [JsonProperty("business_initiated_quantity")]
        public int BusinessInitiatedQuantity { get; set; }

        [JsonProperty("free_entry_point")]
        public int FreeEntryPoint { get; set; }

        [JsonProperty("free_quantity")]
        public int FreeQuantity { get; set; }

        [JsonProperty("free_tier")]
        public int FreeTier { get; set; }

        [JsonProperty("paid_quantity")]
        public int PaidQuantity { get; set; }

        [JsonProperty("period_date")]
        public DateTime PeriodDate { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("total_price")]
        public decimal TotalPrice { get; set; }

        [JsonProperty("user_initiated_paid_quantity")]
        public int UserInitiatedPaidQuantity { get; set; }

        [JsonProperty("user_initiated_price")]
        public decimal UserInitiatedPrice { get; set; }

        [JsonProperty("user_initiated_quantity")]
        public int UserInitiatedQuantity { get; set; }
    }
}