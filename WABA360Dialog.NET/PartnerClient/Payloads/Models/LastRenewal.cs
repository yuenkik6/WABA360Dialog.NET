using System;
using Newtonsoft.Json;

namespace WABA360Dialog.PartnerClient.Payloads.Models
{
    public class LastRenewal
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }
    }
}