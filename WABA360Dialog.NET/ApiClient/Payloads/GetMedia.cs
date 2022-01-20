using System.Net.Http;
using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Base;

namespace WABA360Dialog.ApiClient.Payloads
{
    public class GetMediaRequest : ClientApiRequestBase<GetMediaResponse>
    {
        public GetMediaRequest(string mediaId) : base($"v1/media/{mediaId}", HttpMethod.Get)
        {
            MediaId = mediaId;
        }

        [JsonIgnore]
        public string MediaId { get; }
    }

    public class GetMediaResponse : BinaryApiResponseBase
    {
    }
}