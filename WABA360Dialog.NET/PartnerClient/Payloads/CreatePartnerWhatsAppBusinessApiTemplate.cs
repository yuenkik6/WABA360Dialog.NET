using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.TemplateObjects;
using WABA360Dialog.Common.Enums;
using WABA360Dialog.PartnerClient.Payloads.Base;
using WABA360Dialog.PartnerClient.Payloads.Enums;
using WABA360Dialog.PartnerClient.Payloads.Models;

namespace WABA360Dialog.PartnerClient.Payloads
{
    public class CreatePartnerWhatsAppBusinessApiTemplateRequest : PartnerApiRequestBase<CreatePartnerWhatsAppBusinessApiTemplateResponse>
    {
        public CreatePartnerWhatsAppBusinessApiTemplateRequest(
            string partnerId,
            string whatsAppBusinessApiAccountId,
            string name,
            string category,
            TemplateComponentObject components,
            WhatsAppLanguage language
        )
            : base($"partners/{partnerId}/waba_accounts/{whatsAppBusinessApiAccountId}/waba_templates", HttpMethod.Post)
        {
            PartnerId = partnerId;
            WhatsAppBusinessApiAccountId = whatsAppBusinessApiAccountId;
            Name = name;
            Category = category;
            Components = components;
            Language = language;
        }

        [JsonIgnore]
        public string PartnerId { get; }

        [JsonIgnore]
        public string WhatsAppBusinessApiAccountId { get; }

        [JsonProperty("name")]
        public string Name { get; }

        [JsonProperty("category")]
        public string Category { get; }

        [JsonProperty("components")]
        public TemplateComponentObject Components { get; }

        [JsonProperty("language")]
        public WhatsAppLanguage Language { get; }
    }

    public class CreatePartnerWhatsAppBusinessApiTemplateResponse : PartnerApiResponseBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("partner_id")]
        public string PartnerId { get; set; }

        [JsonProperty("waba_account_id")]
        public string WhatsAppBusinessApiAccountId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public TemplateStatus Status { get; set; }

        [JsonProperty("language")]
        public WhatsAppLanguage Language { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("components")]
        public IEnumerable<object> Components { get; set; }

        [JsonProperty("rejected_reason")]
        public string RejectedReason { get; set; }

        [JsonProperty("namespace")]
        public string Namespace { get; set; }

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