using System.Collections.Generic;
using Newtonsoft.Json;
using WABA360Dialog.Common.Enums;
using WABA360Dialog.PartnerClient.Payloads.Enums;

namespace WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.TemplateObjects
{
    public class WhatsAppBusinessApiTemplate
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public TemplateStatus Status { get; set; }

        [JsonProperty("language")]
        public WhatsAppLanguage Language { get; set; }

        [JsonProperty("category")]
        public TemplateCategory Category { get; set; }

        [JsonProperty("components")]
        public IEnumerable<TemplateComponentObject> Components { get; set; }

        [JsonProperty("rejected_reason")]
        public string RejectedReason { get; set; }

        [JsonProperty("namespace")]
        public string Namespace { get; set; }
    }
}