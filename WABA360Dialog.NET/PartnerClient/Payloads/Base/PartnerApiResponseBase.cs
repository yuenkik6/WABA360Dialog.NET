using Newtonsoft.Json;
using WABA360Dialog.Common.Interfaces;
using WABA360Dialog.PartnerClient.Payloads.Models;

namespace WABA360Dialog.PartnerClient.Payloads.Base
{
    public abstract class PartnerApiResponseBase : IPartnerApiResponse
    {
        /// <summary>
        /// Delete Success / Error Message in general partner API request
        /// </summary>
        [JsonProperty("meta")]
        public PartnerApiMeta Meta { get; set; }
        
        /// <summary>
        /// Error Status in token request
        /// </summary>
        [JsonProperty("error")]
        public string Error { get; set; }
        
        /// <summary>
        /// Error Message in token request
        /// </summary>
        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }
        
        /// <summary>
        /// Http Response Body, for Debug Purpose
        /// </summary>
        [JsonIgnore]
        public string ResponseBody { get; set; }
    }
}