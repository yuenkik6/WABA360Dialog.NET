using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using WABA360Dialog.Cloud.ApiClient.Payloads.Responses;

namespace WABA360Dialog.Cloud.ApiClient.Payloads.Requests
{
    public class UpdateBusinessProfileRequest : WABA360Dialog.ApiClient.Payloads.Base.ClientApiRequestBase<UpdateBusinessProfileResponse>
    {
        public UpdateBusinessProfileRequest(IEnumerable<string> vertical,
            IEnumerable<string> websites,
            string email,
            string description,
            string address) : base("whatsapp_business_profile", HttpMethod.Post)
        {
            Vertical = vertical;
            Websites = websites;
            Email = email;
            Description = description;
            Address = address;
        }

        /// <summary>
        /// Industry of the business.
        /// The business vertical cannot be set back to an empty value after it is created.
        /// </summary>
        [JsonProperty("vertical")]
        public IEnumerable<string> Vertical { get; set; }

        /// <summary>
        /// Maximum of 2 websites with a maximum of 256 characters each.
        /// </summary>
        [JsonProperty("websites")]
        public IEnumerable<string> Websites { get; set; }

        /// <summary>
        /// Maximum of 128 characters
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Maximum of 512 characters
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Maximum of 256 characters
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }
    }
}