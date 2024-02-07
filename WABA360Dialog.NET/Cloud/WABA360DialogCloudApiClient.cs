using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WABA360Dialog.ApiClient;
using WABA360Dialog.Cloud.ApiClient.Interfaces;
using WABA360Dialog.Cloud.ApiClient.Payloads.Models.MessageObjects;
using WABA360Dialog.Cloud.ApiClient.Payloads.Requests;
using WABA360Dialog.Cloud.ApiClient.Payloads.Responses;
using ONPREM = WABA360Dialog.ApiClient.Payloads;

namespace WABA360Dialog.Cloud
{
    public class WABA360DialogCloudApiClient : AbstractWABA360DialogApiClient, IWABA360DialogCloudApiClient
    {
        public const string BASEURL = "https://waba-v2.360dialog.io/";

        public WABA360DialogCloudApiClient(string apiKey) : base(apiKey, new HttpClient())
        {

        }

        public WABA360DialogCloudApiClient(string apiKey, HttpClient httpClient) : base(apiKey, httpClient)
        {

        }

        public override string BasePath => BASEURL;

        public async Task<GetWebhookUrlResponse> GetWebhookUrlAsync(CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new GetWebhookUrlRequest(), cancellationToken);
        }

        public async Task<SetWebhookUrlResponse> SetWebhookUrlAsync(string url, Dictionary<string, string> headers, CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new SetWebhookUrlRequest(url, headers), cancellationToken);
        }

        public async Task<SendMessageResponse> SendMessageAsync(MessageObject message, CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new SendMessageRequest(message), cancellationToken);
        }

        public async Task<SendMessageResponse> SendMessageAsync(object message, CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new SendMessageDynamicRequest(message), cancellationToken);
        }
        public async Task<MarkMessagesAsReadResponse> MarkMessagesAsReadAsync(string messageId, CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new MarkMessagesAsReadRequest(messageId), cancellationToken);
        }

        public async Task<GetMediaInformationResponse> GetMediaInformationAsync(string mediaId, CancellationToken cancellationToken = default)
        {
            var mediaResult = await MakeHttpRequestAsync(new GetMediaInformationRequest(mediaId), cancellationToken);
            if (mediaResult.Id is null || mediaResult.Id == String.Empty)
            {
                return mediaResult;
            }

            mediaResult.Url = mediaResult.Url.Replace("https://lookaside.fbsbx.com/", "");

            return mediaResult;
        }

        public async Task<GetMediaResponse> GetMediaAsync(string relativeUrl, CancellationToken cancellationToken = default)
        {
            return await MakeFileDownloadHttpRequestAsync(new GetMediaRequest(relativeUrl), cancellationToken);
        }

        public async Task<GetMediaResponse> GetMediaAsync(string relativeUrl, Dictionary<string, string> queryParams, CancellationToken cancellationToken = default)
        {
            return await MakeFileDownloadHttpRequestAsync(new GetMediaRequest(relativeUrl, queryParams), cancellationToken);
        }

        public async Task<UploadMediaResponse> UploadMediaAsync(string fileName, byte[] fileBytes, string contentType, CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new UploadMediaRequest(fileName, fileBytes, contentType), cancellationToken);
        }

        public async Task<ONPREM.GetTemplateResponse> GetTemplateAsync(int limit = 1000, int offset = 0, string sort = null, CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new ONPREM.GetTemplateRequest(limit, offset, sort), cancellationToken);
        }

        public async Task<ONPREM.CreateTemplateResponse> CreateTemplateAsync(ONPREM.Models.MessageObjects.TemplateObjects.CreateTemplateObject template, CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new ONPREM.CreateTemplateRequest(template), cancellationToken);
        }

        public async Task<ONPREM.DeleteTemplateResponse> DeleteTemplateAsync(string templateName, CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new ONPREM.DeleteTemplateRequest(templateName), cancellationToken);
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
    }
}