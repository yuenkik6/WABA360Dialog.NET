using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Base;

namespace WABA360Dialog.ApiClient.Payloads
{
    public class UpdateBusinessProfileRequest : ClientApiRequestBase<UpdateBusinessProfileResponse>
    {
        public UpdateBusinessProfileRequest(IEnumerable<string> vertical,
            IEnumerable<string> websites,
            string email,
            string description,
            string address) : base("v1/settings/business/profile", HttpMethod.Post)
        {
            Vertical = vertical;
            Websites = websites;
            Email = email;
            Description = description;
            Address = address;
        }

        [JsonProperty("vertical")]
        public IEnumerable<string> Vertical { get; set; }

        [JsonProperty("websites")]
        public IEnumerable<string> Websites { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }
    }

    public class UpdateBusinessProfileResponse : ClientApiResponseBase
    {
    }
}