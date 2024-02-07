using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WABA360Dialog.ApiClient.Interfaces;
using WABA360Dialog.ApiClient.Payloads;
using WABA360Dialog.ApiClient.Payloads.Enums;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.TemplateObjects;

namespace WABA360Dialog.ApiClient
{
    public abstract class WABA360DialogApiClientBase : AbstractWABA360DialogApiClient, IWABA360DialogApiClient, IDisposable
    {
        public WABA360DialogApiClientBase(string apiKey, HttpClient httpClient)
            : base(apiKey, httpClient)
        {

        }

        public async Task<GetWebhookUrlResponse> GetWebhookUrlAsync(CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new GetWebhookUrlRequest(), cancellationToken);
        }

        public async Task<SetWebhookUrlResponse> SetWebhookUrlAsync(string url, Dictionary<string, string> headers, CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new SetWebhookUrlRequest(url, headers), cancellationToken);
        }

        [Obsolete]
        public async Task<CheckContactsResponse> CheckContactsAsync(IEnumerable<string> contacts, Blocking blocking = Blocking.no_wait, bool forceCheck = false, CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new CheckContactsRequest(contacts, blocking, forceCheck), cancellationToken);
        }

        public async Task<SendMessageResponse> SendMessageAsync(MessageObject message, CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new SendMessageRequest(message), cancellationToken);
        }

        public async Task<MarkMessagesAsReadResponse> MarkMessagesAsReadAsync(string messageId, CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new MarkMessagesAsReadRequest(messageId), cancellationToken);
        }

        public async Task<SendMessageResponse> SendMessageAsync(object message, CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new SendMessageDynamicRequest(message), cancellationToken);
        }

        public async Task<GetMediaResponse> GetMediaAsync(string mediaId, CancellationToken cancellationToken = default)
        {
            return await MakeFileDownloadHttpRequestAsync(new GetMediaRequest(mediaId), cancellationToken);
        }

        public async Task<UploadMediaResponse> UploadMediaAsync(byte[] fileBytes, string contentType, CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new UploadMediaRequest(fileBytes, contentType), cancellationToken);
        }

        public async Task<GetTemplateResponse> GetTemplateAsync(int limit = 1000, int offset = 0, string sort = null, CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new GetTemplateRequest(limit, offset, sort), cancellationToken);
        }

        public async Task<CreateTemplateResponse> CreateTemplateAsync(CreateTemplateObject template, CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new CreateTemplateRequest(template), cancellationToken);
        }

        public async Task<DeleteTemplateResponse> DeleteTemplateAsync(string templateName, CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new DeleteTemplateRequest(templateName), cancellationToken);
        }

        public async Task<UpdateBusinessProfileResponse> UpdateBusinessProfileAsync(
            IEnumerable<string> vertical,
            IEnumerable<string> websites,
            string email,
            string description,
            string address,
            CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new UpdateBusinessProfileRequest(vertical, websites, email, description, address), cancellationToken);
        }

        public async Task<UpdateProfileInfoAboutTextResponse> UpdateProfileInfoAboutTextAsync(string aboutText, CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new UpdateProfileInfoAboutTextRequest(aboutText), cancellationToken);
        }

        public async Task<UpdateProfileInfoPhotoResponse> UpdateProfileInfoPhotoAsync(byte[] fileBytes, string contentType, CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new UpdateProfileInfoPhotoRequest(fileBytes, contentType), cancellationToken);
        }

        public async Task<CheckPhoneNumberResponse> CheckPhoneNumberAsync(CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new CheckPhoneNumberRequest(), cancellationToken);
        }

        public async Task<HealthCheckResponse> HealthCheckAsync(CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new HealthCheckRequest(), cancellationToken);
        }
    }
}