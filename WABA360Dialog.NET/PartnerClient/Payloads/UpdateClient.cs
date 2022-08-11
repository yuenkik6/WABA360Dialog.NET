using System;
using System.Net.Http;
using Newtonsoft.Json;
using WABA360Dialog.PartnerClient.Payloads.Base;
using WABA360Dialog.PartnerClient.Payloads.Enums;
using WABA360Dialog.PartnerClient.Payloads.Models;

namespace WABA360Dialog.PartnerClient.Payloads
{
    public class UpdateClientRequest : PartnerApiRequestBase<UpdateClientResponse>
    {
        public UpdateClientRequest(string partnerId, string clientId, string partnerPayload, int? maxChannels = null)
            : base($"partners/{partnerId}/clients/{clientId}", new HttpMethod("PATCH"))
        {
            PartnerId = partnerId;
            ClientId = clientId;
            PartnerPayload = partnerPayload;
        }

        [JsonIgnore]
        public string PartnerId { get; }

        [JsonIgnore]
        public string ClientId { get; }

        [JsonProperty("partner_payload")]
        public string PartnerPayload { get; set; }
        
        [JsonProperty("max_channels")]
        public int? MaxChannels { get; set; }
    }

    public class UpdateClientResponse : PartnerApiResponseBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public ClientStatus Status { get; set; }

        [JsonProperty("organisation")]
        public string Organisation { get; set; }

        [JsonProperty("meta_info")]
        public MetaInfo MetaInfo { get; set; }

        [JsonProperty("contact_info")]
        public ClientContactInfo ContactInfo { get; set; }

        [JsonProperty("contact_user")]
        public ContactUser ContactUser { get; set; }

        [JsonProperty("partner_payload")]
        public string PartnerPayload { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("created_by")]
        public CreatedBy CreatedBy { get; set; }

        [JsonProperty("modified_at")]
        public DateTime ModifiedAt { get; set; }

        [JsonProperty("modified_by")]
        public ModifiedBy ModifiedBy { get; set; }
    }
}