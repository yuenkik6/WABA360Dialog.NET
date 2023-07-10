using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using WABA360Dialog.ApiClient.Exceptions;
using WABA360Dialog.ApiClient.Interfaces;
using WABA360Dialog.ApiClient.Payloads;
using WABA360Dialog.ApiClient.Payloads.Base;
using WABA360Dialog.ApiClient.Payloads.Enums;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.TemplateObjects;
using WABA360Dialog.Common.Helpers;

namespace WABA360Dialog.ApiClient
{
    public abstract class WABA360DialogApiClientBase : IWABA360DialogApiClient
    {
        private string BasePath { get; }
        private readonly string _apiKey;
        protected readonly HttpClient HttpClient;

        protected WABA360DialogApiClientBase(string apiKey, string basePath, HttpClient httpClient)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentNullException(nameof(apiKey), "API Key cannot be null.");

            _apiKey = apiKey;
            BasePath = basePath;
            HttpClient = httpClient;
        }

        public async Task<GetWebhookUrlResponse> GetWebhookUrlAsync(CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new GetWebhookUrlRequest(), cancellationToken);
        }

        public async Task<SetWebhookUrlResponse> SetWebhookUrlAsync(string url, Dictionary<string, string> headers, CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new SetWebhookUrlRequest(url, headers), cancellationToken);
        }

        public async Task<CheckContactsResponse> CheckContactsAsync(IEnumerable<string> contacts, Blocking blocking = Blocking.no_wait, bool forceCheck = false, CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new CheckContactsRequest(contacts, blocking, forceCheck), cancellationToken);
        }

        public async Task<SendMessageResponse> SendMessageAsync(MessageObject message, CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new SendMessageRequest(message), cancellationToken);
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

        protected virtual async Task<TResponse> MakeHttpRequestAsync<TResponse>(ClientApiRequestBase<TResponse> request, CancellationToken cancellationToken = default) where TResponse : ClientApiResponseBase, new()
        {
            var requestPath = BasePath + request.MethodName;
            var urlBuilder = new UriBuilder(requestPath);

            if (request.QueryParams != null)
            {
                var query = HttpUtility.ParseQueryString(string.Empty);

                foreach (var queryParam in request.QueryParams.Where(queryParam => queryParam.Value != null))
                    query[queryParam.Key] = queryParam.Value;

                urlBuilder.Query = query.ToString();
            }

            var httpRequestMessage = new HttpRequestMessage(request.Method, urlBuilder.Uri);

            if (request.Method != HttpMethod.Get)
            {
                httpRequestMessage.Content = request.ToHttpContent();
            }

            httpRequestMessage.Headers.Add("D360-API-KEY", _apiKey);

            var httpResponse = await HttpClient.SendAsync(httpRequestMessage, cancellationToken);

            var responseAsString = await httpResponse.Content.ReadAsStringAsync();
            JsonHelper.TryDeserializeJson<TResponse>(responseAsString, out var response);

            if (!httpResponse.IsSuccessStatusCode || response == null)
            {
                if (!string.IsNullOrWhiteSpace(responseAsString))
                {
                    JsonHelper.TryDeserializeJson<ErrorClientApiResponse>(responseAsString, out var errorResponse);

                    if (errorResponse != null)
                        throw new ApiClientException(errorResponse.Error, errorResponse.Meta, urlBuilder.ToString(), (int)httpResponse.StatusCode, await request.ToHttpContent().ReadAsStringAsync(), responseAsString);
                }

                throw new ApiClientException(urlBuilder.ToString(), (int)httpResponse.StatusCode, await request.ToHttpContent().ReadAsStringAsync(), responseAsString);
            }

            response.ResponseBody = responseAsString;

            return response;
        }

        protected virtual async Task<TResponse> MakeFileDownloadHttpRequestAsync<TResponse>(ClientApiRequestBase<TResponse> request, CancellationToken cancellationToken = default) where TResponse : BinaryApiResponseBase, new()
        {
            var requestPath = BasePath + request.MethodName;
            var urlBuilder = new UriBuilder(requestPath);

            if (request.QueryParams != null)
            {
                var query = HttpUtility.ParseQueryString(string.Empty);

                foreach (var queryParam in request.QueryParams.Where(queryParam => queryParam.Value != null))
                    query[queryParam.Key] = queryParam.Value;

                urlBuilder.Query = query.ToString();
            }

            var httpRequestMessage = new HttpRequestMessage(request.Method, urlBuilder.Uri);

            if (request.Method != HttpMethod.Get)
            {
                httpRequestMessage.Content = request.ToHttpContent();
            }

            httpRequestMessage.Headers.Add("D360-API-KEY", _apiKey);

            var httpResponse = await HttpClient.SendAsync(httpRequestMessage, cancellationToken);

            if (!httpResponse.IsSuccessStatusCode)
            {
                var responseAsString = await httpResponse.Content.ReadAsStringAsync();

                if (!string.IsNullOrWhiteSpace(responseAsString))
                {
                    JsonHelper.TryDeserializeJson<ErrorClientApiResponse>(responseAsString, out var errorResponse);

                    if (errorResponse != null)
                        throw new ApiClientException(errorResponse.Error, errorResponse.Meta, urlBuilder.ToString(), (int)httpResponse.StatusCode, await request.ToHttpContent().ReadAsStringAsync(), responseAsString);
                }

                throw new ApiClientException(urlBuilder.ToString(), (int)httpResponse.StatusCode, await request.ToHttpContent().ReadAsStringAsync(), responseAsString);
            }

            var responseAsByte = await httpResponse.Content.ReadAsByteArrayAsync();

            var result = new TResponse
            {
                FileBytes = responseAsByte,
                ContentType = httpResponse.Content.Headers.ContentType,
                ContentDisposition = httpResponse.Content.Headers.ContentDisposition,
                ContentLength = httpResponse.Content.Headers.ContentLength ?? 0,
            };

            return result;
        }
    }
}