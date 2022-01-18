using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using WABA360Dialog.Common.Helpers;
using WABA360Dialog.Common.Interfaces;

namespace WABA360Dialog.ApiClient.Payloads.Base
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public abstract class ClientApiRequestBase<TResponse> : IRequest<TResponse> where TResponse : ClientApiResponseBase
    {
        [JsonIgnore]
        public HttpMethod Method { get; protected set; }

        [JsonIgnore]
        public string MethodName { get; protected set; }
        
        [JsonIgnore]
        public Dictionary<string,string> QueryParams { get; protected set; }

        protected ClientApiRequestBase(string methodName, HttpMethod method)
        {
            MethodName = methodName;
            Method = method;
        }

        protected ClientApiRequestBase(string methodName, HttpMethod method, Dictionary<string,string> queryParams)
        {
            MethodName = methodName;
            Method = method;
            QueryParams = queryParams;
        }

        public virtual HttpContent ToHttpContent()
        {
            var payload = JsonHelper.SerializeObjectToJson(this);

            var content = new StringContent(payload, Encoding.UTF8, "application/json");
            
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return content;
        }
    }

}