using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WABA360Dialog.ApiClient.Payloads;
using WABA360Dialog.ApiClient.Payloads.Enums;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.TemplateObjects;

namespace WABA360Dialog.ApiClient.Interfaces
{
    public interface IWABA360DialogApiClient
    {
        Task<GetWebhookUrlResponse> GetWebhookUrlAsync(CancellationToken cancellationToken = default);
        Task<SetWebhookUrlResponse> SetWebhookUrlAsync(string url, Dictionary<string, string> headers, CancellationToken cancellationToken = default);
        Task<CheckContactsResponse> CheckContactsAsync(IEnumerable<string> contacts, Blocking blocking = Blocking.no_wait, bool forceCheck = false, CancellationToken cancellationToken = default);
        Task<SendMessageResponse> SendMessageAsync(MessageObject message, CancellationToken cancellationToken = default);
        Task<SendMessageResponse> SendMessageAsync(object message, CancellationToken cancellationToken = default);
        Task<GetMediaResponse> GetMediaAsync(string mediaId, CancellationToken cancellationToken = default);
        Task<UploadMediaResponse> UploadMediaAsync(byte[] fileBytes, string contentType, CancellationToken cancellationToken = default);
        Task<GetTemplateResponse> GetTemplateAsync(int limit = 1000, int offset = 0, string sort = null, CancellationToken cancellationToken = default);
        Task<CreateTemplateResponse> CreateTemplateAsync(CreateTemplateObject template, CancellationToken cancellationToken = default);
        Task<DeleteTemplateResponse> DeleteTemplateAsync(string templateName, CancellationToken cancellationToken = default);

        Task<UpdateBusinessProfileResponse> UpdateBusinessProfileAsync(
            IEnumerable<string> vertical,
            IEnumerable<string> websites,
            string email,
            string description,
            string address,
            CancellationToken cancellationToken = default);

        Task<UpdateProfileInfoAboutTextResponse> UpdateProfileInfoAboutTextAsync(string aboutText, CancellationToken cancellationToken = default);
        Task<UpdateProfileInfoPhotoResponse> UpdateProfileInfoPhotoAsync(byte[] fileBytes, string contentType, CancellationToken cancellationToken = default);
    }
}