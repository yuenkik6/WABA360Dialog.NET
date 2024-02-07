using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WABA360Dialog.Cloud.ApiClient.Payloads.Models.MessageObjects;
using WABA360Dialog.Cloud.ApiClient.Payloads.Responses;
using ONPREM = WABA360Dialog.ApiClient.Payloads;

namespace WABA360Dialog.Cloud.ApiClient.Interfaces
{
    public interface IWABA360DialogCloudApiClient
    {
        Task<GetWebhookUrlResponse> GetWebhookUrlAsync(CancellationToken cancellationToken = default);
        Task<SetWebhookUrlResponse> SetWebhookUrlAsync(string url, Dictionary<string, string> headers, CancellationToken cancellationToken = default);
        Task<SendMessageResponse> SendMessageAsync(MessageObject message, CancellationToken cancellationToken = default);
        Task<SendMessageResponse> SendMessageAsync(object message, CancellationToken cancellationToken = default);
        Task<MarkMessagesAsReadResponse> MarkMessagesAsReadAsync(string messageId, CancellationToken cancellationToken = default);
        Task<GetMediaInformationResponse> GetMediaInformationAsync(string mediaId, CancellationToken cancellationToken = default);
        Task<GetMediaResponse> GetMediaAsync(string relativeUrl, CancellationToken cancellationToken = default);
        Task<GetMediaResponse> GetMediaAsync(string relativeUrl, Dictionary<string, string> queryParams, CancellationToken cancellationToken = default);
        Task<UploadMediaResponse> UploadMediaAsync(string fileName, byte[] fileBytes, string contentType, CancellationToken cancellationToken = default);
        Task<ONPREM.GetTemplateResponse> GetTemplateAsync(int limit = 1000, int offset = 0, string sort = null, CancellationToken cancellationToken = default);
        Task<ONPREM.CreateTemplateResponse> CreateTemplateAsync(ONPREM.Models.MessageObjects.TemplateObjects.CreateTemplateObject template, CancellationToken cancellationToken = default);
        Task<ONPREM.DeleteTemplateResponse> DeleteTemplateAsync(string templateName, CancellationToken cancellationToken = default);
        Task<UpdateBusinessProfileResponse> UpdateBusinessProfileAsync(IEnumerable<string> vertical, IEnumerable<string> websites, string email, string description, string address, CancellationToken cancellationToken = default);
    }
}