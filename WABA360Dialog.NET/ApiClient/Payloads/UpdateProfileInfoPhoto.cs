using System.Net.Http;
using WABA360Dialog.ApiClient.Payloads.Base;

namespace WABA360Dialog.ApiClient.Payloads
{
    public class UpdateProfileInfoPhotoRequest : BinaryApiRequestBase<UpdateProfileInfoPhotoResponse>
    {
        public UpdateProfileInfoPhotoRequest(byte[] fileBytes, string contentType) : base(fileBytes, contentType, "v1/settings/profile/photo", HttpMethod.Post)
        {
        }
    }

    public class UpdateProfileInfoPhotoResponse : ClientApiResponseBase
    {
    }
}