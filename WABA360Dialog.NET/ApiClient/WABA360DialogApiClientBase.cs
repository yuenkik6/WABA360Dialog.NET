using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
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

        protected WABA360DialogApiClientBase(string apiKey, string basePath)
        {
            _apiKey = apiKey;
            BasePath = basePath;
        }

        public async Task<GetWebhookUrlResponse> GetWebhookUrlAsync()
        {
            return await MakeHttpRequestAsync(new GetWebhookUrlRequest());
        }

        public async Task<SetWebhookUrlResponse> SetWebhookUrlAsync(string url, Dictionary<string, string> headers)
        {
            return await MakeHttpRequestAsync(new SetWebhookUrlRequest(url, headers));
        }

        public async Task<CheckContactsResponse> CheckContactsAsync(IEnumerable<string> contacts, Blocking blocking = Blocking.no_wait, bool forceCheck = false)
        {
            return await MakeHttpRequestAsync(new CheckContactsRequest(contacts, blocking, forceCheck));
        }

        public async Task<SendMessageResponse> SendMessageAsync(MessageObject message)
        {
            return await MakeHttpRequestAsync(new SendMessageRequest(message));
        }

        public async Task<SendMessageResponse> SendMessageAsync(object message)
        {
            return await MakeHttpRequestAsync(new SendMessageDynamicRequest(message));
        }

        public async Task<GetMediaResponse> GetMediaAsync(string mediaId)
        {
            return await MakeFileDownloadHttpRequestAsync(new GetMediaRequest(mediaId));
        }

        public async Task<UploadMediaResponse> UploadMediaAsync(byte[] fileBytes, string contentType)
        {
            return await MakeHttpRequestAsync(new UploadMediaRequest(fileBytes, contentType));
        }

        public async Task<CreateTemplateResponse> CreateTemplateAsync(CreateTemplateObject template)
        {
            return await MakeHttpRequestAsync(new CreateTemplateRequest(template));
        }

        public async Task<UpdateBusinessProfileResponse> UpdateBusinessProfileAsync(
            IEnumerable<string> vertical,
            IEnumerable<string> websites,
            string email,
            string description,
            string address)
        {
            return await MakeHttpRequestAsync(new UpdateBusinessProfileRequest(vertical, websites, email, description, address));
        }

        public async Task<UpdateProfileInfoAboutTextResponse> UpdateProfileInfoAboutTextAsync(string aboutText)
        {
            return await MakeHttpRequestAsync(new UpdateProfileInfoAboutTextRequest(aboutText));
        }

        public async Task<UpdateProfileInfoPhotoResponse> UpdateProfileInfoPhotoAsync(byte[] fileBytes, string contentType)
        {
            return await MakeHttpRequestAsync(new UpdateProfileInfoPhotoRequest(fileBytes, contentType));
        }

        protected virtual async Task<TResponse> MakeHttpRequestAsync<TResponse>(ClientApiRequestBase<TResponse> request, CancellationToken cancellationToken = default) where TResponse : ClientApiResponseBase, new()
        {
            using var client = new HttpClient();

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

            var httpResponse = await client.SendAsync(httpRequestMessage, cancellationToken);

            var responseAsString = await httpResponse.Content.ReadAsStringAsync();
            JsonHelper.TryDeserializeJson<TResponse>(responseAsString, out var response);

            if (response == null)
                throw new ApiClientException(urlBuilder.ToString(), (int)httpResponse.StatusCode, await request.ToHttpContent().ReadAsStringAsync(), responseAsString);

            if (!httpResponse.IsSuccessStatusCode)
                throw new ApiClientException(response.Error, response.Meta, urlBuilder.ToString(), (int)httpResponse.StatusCode, await request.ToHttpContent().ReadAsStringAsync(), responseAsString);
            
            return response;
        }

        protected virtual async Task<TResponse> MakeFileDownloadHttpRequestAsync<TResponse>(ClientApiRequestBase<TResponse> request, CancellationToken cancellationToken = default) where TResponse : BinaryApiResponseBase, new()
        {
            using var client = new HttpClient();

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

            var httpResponse = await client.SendAsync(httpRequestMessage, cancellationToken);

            if (!httpResponse.IsSuccessStatusCode)
            {
                var responseAsString = await httpResponse.Content.ReadAsStringAsync();

                if (JsonHelper.TryDeserializeJson<TResponse>(responseAsString, out var response))
                {
                    throw new ApiClientException(response.Error, response.Meta, urlBuilder.ToString(), (int)httpResponse.StatusCode, await request.ToHttpContent().ReadAsStringAsync(), responseAsString);
                }
                else
                {
                    throw new ApiClientException(urlBuilder.ToString(), (int)httpResponse.StatusCode, await request.ToHttpContent().ReadAsStringAsync(), responseAsString);
                }
            }

            var responseAsByte = await httpResponse.Content.ReadAsByteArrayAsync();

            return new TResponse
            {
                FileBytes = responseAsByte
            };
        }
    }
}