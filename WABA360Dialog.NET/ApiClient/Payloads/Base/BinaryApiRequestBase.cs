using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WABA360Dialog.ApiClient.Payloads.Base
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public abstract class BinaryApiRequestBase<TResponse> : ClientApiRequestBase<TResponse> where TResponse : ClientApiResponseBase
    {
        protected BinaryApiRequestBase(byte[] fileBytes, string contentType, string methodName, HttpMethod method) : base(methodName, method)
        {
            FileBytes = fileBytes;
            ContentType = contentType;
        }
        
        public byte[] FileBytes { get; }
        public string ContentType { get; }

        public override HttpContent ToHttpContent()
        {
            var byteArrayContent = new ByteArrayContent(FileBytes);

            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(ContentType);

            return byteArrayContent;
        }
    }
    
    
}