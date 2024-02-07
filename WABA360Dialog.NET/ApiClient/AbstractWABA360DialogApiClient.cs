using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using WABA360Dialog.ApiClient.Exceptions;
using WABA360Dialog.ApiClient.Payloads.Base;
using WABA360Dialog.Common.Helpers;

namespace WABA360Dialog.ApiClient
{
    public abstract class AbstractWABA360DialogApiClient : IDisposable
    {
        private readonly string _apiKey;

        protected AbstractWABA360DialogApiClient(string apiKey, HttpClient httpClient)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentNullException(nameof(apiKey), "API Key cannot be null.");

            _apiKey = apiKey;
            HttpClient = httpClient;
        }

        public abstract string BasePath { get; }
        protected HttpClient HttpClient { get; }

        public void Dispose()
        {
            HttpClient.Dispose();
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
            httpRequestMessage.Headers.Add("User-Agent", "Mozilla/5.0");

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
