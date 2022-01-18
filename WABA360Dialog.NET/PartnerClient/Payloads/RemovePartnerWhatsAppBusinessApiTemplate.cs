using System.Net.Http;
using Newtonsoft.Json;
using WABA360Dialog.PartnerClient.Payloads.Base;

namespace WABA360Dialog.PartnerClient.Payloads
{
    public class RemovePartnerWhatsAppBusinessApiTemplatesRequest : PartnerApiRequestBase<RemovePartnerWhatsAppBusinessApiTemplatesResponse>
    {
        public RemovePartnerWhatsAppBusinessApiTemplatesRequest(string partnerId, string whatsAppBusinessApiAccountId, string templateId)
            : base($"partners/{partnerId}/waba_accounts/{whatsAppBusinessApiAccountId}/waba_templates/{templateId}", HttpMethod.Delete)
        {
            PartnerId = partnerId;
            WhatsAppBusinessApiAccountId = whatsAppBusinessApiAccountId;
            TemplateId = templateId;
        }

        [JsonIgnore]
        public string PartnerId { get; }

        [JsonIgnore]
        public string WhatsAppBusinessApiAccountId { get; }

        [JsonIgnore]
        public string TemplateId { get; }

    }

    public class RemovePartnerWhatsAppBusinessApiTemplatesResponse : PartnerApiResponseBase
    {
    }

}