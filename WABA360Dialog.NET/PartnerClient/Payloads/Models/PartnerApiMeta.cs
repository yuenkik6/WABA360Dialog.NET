using System.Collections.Generic;
using Newtonsoft.Json;

namespace WABA360Dialog.PartnerClient.Payloads.Models
{
    public class PartnerApiMeta
    {
        [JsonProperty("success")]
        public bool? Success { get; set; }

        [JsonProperty("http_code")]
        public int? HttpCode { get; set; }

        [JsonProperty("developer_message")]
        public string DeveloperMessage { get; set; }

        [JsonProperty("details")]
        public IEnumerable<string> Details { get; set; }

        [JsonProperty("error_data")]
        public ErrorData ErrorData { get; set; }
    }

    public class ErrorData
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("real_message")]
        public string RealMessage { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }
    }

}