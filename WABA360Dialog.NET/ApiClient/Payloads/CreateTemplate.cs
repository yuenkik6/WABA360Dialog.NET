using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Base;
using WABA360Dialog.ApiClient.Payloads.Enums;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.InteractiveObjects;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.TemplateObjects;
using WABA360Dialog.Common.Helpers;

namespace WABA360Dialog.ApiClient.Payloads
{
    public class CreateTemplateRequest : ClientApiRequestBase<CreateTemplateResponse>
    {
        public CreateTemplateRequest(CreateTemplateObject template) : base("v1/configs/templates", HttpMethod.Post)
        {
            Template = template;
        }

        public CreateTemplateObject Template { get; }

        public override HttpContent ToHttpContent()
        {
            var payload = JsonHelper.SerializeObjectToJson(Template);
            
            var content = new StringContent(payload, Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return content;
        }
    }

    public class CreateTemplateResponse : ClientApiResponseBase
    {
        /// <summary>
        /// Required.
        /// Namespace of the template.
        /// </summary>
        [JsonProperty("namespace")]
        public string Namespace { get; set; }

        /// <summary>
        /// Required.
        /// Name of the template.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Required.
        /// Contains a language object. Specifies the language the template may be rendered in.
        /// Only the deterministic language policy works with media template messages.
        /// </summary>
        [JsonProperty("language")]
        public LanguageObject Language { get; set; }

        /// <summary>
        /// Optional.
        /// Array of components objects containing the parameters of the message.
        /// </summary>
        [JsonProperty("components")]
        public IEnumerable<ComponentObject> Components { get; set; }
        
    }
}