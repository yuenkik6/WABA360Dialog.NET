using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WABA360Dialog.ApiClient.Payloads.Base;
using WABA360Dialog.ApiClient.Payloads.Enums;
using WABA360Dialog.ApiClient.Payloads.Models;

namespace WABA360Dialog.ApiClient.Payloads
{
    public class HealthCheckRequest : ClientApiRequestBase<HealthCheckResponse>
    {
        public HealthCheckRequest() : base("v1/health", HttpMethod.Get)
        {
        }
    }

    public class HealthCheckResponse : ClientApiResponseBase
    {
        [JsonProperty("health")] 
        public JObject Health { get; set; }
    }
}