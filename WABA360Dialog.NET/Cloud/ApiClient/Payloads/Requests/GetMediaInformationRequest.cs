using Newtonsoft.Json;
using System.Net.Http;
using WABA360Dialog.Cloud.ApiClient.Payloads.Responses;
namespace WABA360Dialog.Cloud.ApiClient.Payloads.Requests
{
    public class GetMediaInformationRequest : WABA360Dialog.ApiClient.Payloads.Base.ClientApiRequestBase<GetMediaInformationResponse>
    {
        public GetMediaInformationRequest(string mediaId) : base(mediaId, HttpMethod.Get)
        {
            MediaId = mediaId;
        }

        [JsonIgnore]
        public string MediaId { get; }
    }
}