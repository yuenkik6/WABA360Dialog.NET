using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.TemplateObjects;
using WABA360Dialog.Common.Enums;
using WABA360Dialog.PartnerClient.Payloads.Enums;

namespace WABA360Dialog.PartnerClient.Payloads.Models
{
    public class PartnerWhatsAppBusinessApiTemplate
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
        public IEnumerable<TemplateComponentObject> Components { get; set; }

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