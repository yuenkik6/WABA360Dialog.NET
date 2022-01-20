using System.Net.Http;
using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Base;

namespace WABA360Dialog.ApiClient.Payloads
{
    public class DeleteTemplateRequest : ClientApiRequestBase<DeleteTemplateResponse>
    {
        public DeleteTemplateRequest(string templateName) : base($"v1/configs/templates/{templateName}", HttpMethod.Delete)
        {
        }

        [JsonIgnore]
        public string TemplateName { get; }
    }

    public class DeleteTemplateResponse : ClientApiResponseBase
    {
    }
}