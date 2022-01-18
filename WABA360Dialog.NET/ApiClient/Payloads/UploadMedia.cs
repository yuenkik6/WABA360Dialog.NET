using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Base;
using WABA360Dialog.ApiClient.Payloads.Models;

namespace WABA360Dialog.ApiClient.Payloads
{
    public class UploadMediaRequest : BinaryApiRequestBase<UploadMediaResponse>
    {
        public UploadMediaRequest(byte[] fileBytes, string contentType) : base(fileBytes, contentType, "v1/media", HttpMethod.Post)
        {
        }
    }
    
    public class UploadMediaResponse : ClientApiResponseBase
    {
        [JsonProperty("media")]
        public IEnumerable<UploadMediaResult> Media { get; set; }
    }

}