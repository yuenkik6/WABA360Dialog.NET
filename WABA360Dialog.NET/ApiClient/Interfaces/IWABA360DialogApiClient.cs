using System.Collections.Generic;
using System.Threading.Tasks;
using WABA360Dialog.ApiClient.Payloads;
using WABA360Dialog.ApiClient.Payloads.Enums;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.TemplateObjects;

namespace WABA360Dialog.ApiClient.Interfaces
{
    public interface IWABA360DialogApiClient
    {
        Task<GetWebhookUrlResponse> GetWebhookUrlAsync();
        Task<SetWebhookUrlResponse> SetWebhookUrlAsync(string url, Dictionary<string, string> headers);
        Task<CheckContactsResponse> CheckContactsAsync(IEnumerable<string> contacts, Blocking blocking = Blocking.no_wait, bool forceCheck = false);
        Task<SendMessageResponse> SendMessageAsync(MessageObject message);
        Task<SendMessageResponse> SendMessageAsync(object message);
        Task<GetMediaResponse> GetMediaAsync(string mediaId);
        Task<UploadMediaResponse> UploadMediaAsync(byte[] fileBytes, string contentType);
        Task<CreateTemplateResponse> CreateTemplateAsync(CreateTemplateObject template);

        Task<UpdateBusinessProfileResponse> UpdateBusinessProfileAsync(
            IEnumerable<string> vertical,
            IEnumerable<string> websites,
            string email,
            string description,
            string address);

        Task<UpdateProfileInfoAboutTextResponse> UpdateProfileInfoAboutTextAsync(string aboutText);
        Task<UpdateProfileInfoPhotoResponse> UpdateProfileInfoPhotoAsync(byte[] fileBytes, string contentType);
    }
}