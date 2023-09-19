using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.TemplateObjects;
using WABA360Dialog.Common.Enums;
using WABA360Dialog.Common.Helpers;
using WABA360Dialog.PartnerClient.Exceptions;
using WABA360Dialog.PartnerClient.Interfaces;
using WABA360Dialog.PartnerClient.Models;
using WABA360Dialog.PartnerClient.Payloads;
using WABA360Dialog.PartnerClient.Payloads.Base;

namespace WABA360Dialog
{
    public class WABA360DialogPartnerClient : IWABA360DialogPartnerClient, IDisposable
    {
        private const string BasePath = "https://hub.360dialog.io/api/v2/";

        private readonly PartnerInfo _partnerInfo;
        private string _accessToken;
        protected readonly HttpClient HttpClient;

        public WABA360DialogPartnerClient(PartnerInfo partnerInfo)
        {
            if (partnerInfo == null)
                throw new ArgumentNullException(nameof(partnerInfo), "Partner Info cannot be null.");

            if (string.IsNullOrEmpty(partnerInfo.PartnerId) || string.IsNullOrEmpty(partnerInfo.Username) || string.IsNullOrEmpty(partnerInfo.Password))
                throw new ArgumentException("Partner Info cannot be null.");

            _partnerInfo = partnerInfo;

            HttpClient = new HttpClient();
        }

        public WABA360DialogPartnerClient(PartnerInfo partnerInfo, HttpClient httpClient)
        {
            if (partnerInfo == null)
                throw new ArgumentNullException(nameof(partnerInfo), "Partner Info cannot be null.");

            if (string.IsNullOrEmpty(partnerInfo.PartnerId) || string.IsNullOrEmpty(partnerInfo.Username) || string.IsNullOrEmpty(partnerInfo.Password))
                throw new ArgumentException("Partner Info cannot be null.");

            _partnerInfo = partnerInfo;

            HttpClient = httpClient;
        }

        public WABA360DialogPartnerClient(PartnerInfo partnerInfo, string accessToken)
        {
            if (partnerInfo == null)
                throw new ArgumentNullException(nameof(partnerInfo), "Partner Info cannot be null.");

            if (string.IsNullOrEmpty(partnerInfo.PartnerId))
                throw new ArgumentNullException(nameof(partnerInfo.PartnerId), "Partner ID cannot be null.");

            if (string.IsNullOrEmpty(accessToken))
                throw new ArgumentNullException(nameof(accessToken), "Access Token cannot be null.");

            _partnerInfo = partnerInfo;
            _accessToken = accessToken;
            
            HttpClient = new HttpClient();
        }

        public WABA360DialogPartnerClient(PartnerInfo partnerInfo, string accessToken, HttpClient httpClient)
        {
            if (partnerInfo == null)
                throw new ArgumentNullException(nameof(partnerInfo), "Partner Info cannot be null.");

            if (string.IsNullOrEmpty(partnerInfo.PartnerId))
                throw new ArgumentNullException(nameof(partnerInfo.PartnerId), "Partner ID cannot be null.");

            if (string.IsNullOrEmpty(accessToken))
                throw new ArgumentNullException(nameof(accessToken), "Access Token cannot be null.");

            _partnerInfo = partnerInfo;
            _accessToken = accessToken;

            HttpClient = httpClient;
        }

        public async Task<CreatePartnerWhatsAppBusinessApiTemplateResponse> CreatePartnerWhatsAppBusinessApiTemplateAsync(string whatsAppBusinessApiAccountId,
            string name,
            string category,
            WhatsAppLanguage language,
            TemplateComponentObject components,
            CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new CreatePartnerWhatsAppBusinessApiTemplateRequest(_partnerInfo.PartnerId,
                whatsAppBusinessApiAccountId,
                name,
                category,
                components,
                language), cancellationToken);
        }

        public async Task<GetClientBalanceResponse> GetClientBalanceAsync(string clientId, int fromMonth, int fromYear, CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new GetClientBalanceRequest(_partnerInfo.PartnerId, clientId, fromMonth, fromYear), cancellationToken);
        }

        public async Task<GetPartnerChannelsResponse> GetPartnerChannelsAsync(int limit = 20, int offset = 0, string sort = null, GetPartnerChannelsFilter filters = null, CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new GetPartnerChannelsRequest(_partnerInfo.PartnerId, limit, offset, sort, filters), cancellationToken);
        }

        public async Task<GetPartnerClientsResponse> GetPartnerClientsAsync(int limit = 20, int offset = 0, string sort = null, GetPartnerClientsFilter filters = null, CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new GetPartnerClientsRequest(_partnerInfo.PartnerId, limit, offset, sort, filters), cancellationToken);
        }

        public async Task<GetPartnerWebhookUrlResponse> GetPartnerWebhookUrlAsync(CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new GetPartnerWebhookUrlRequest(_partnerInfo.PartnerId), cancellationToken);
        }

        public async Task<SetPartnerWebhookUrlResponse> SetPartnerWebhookUrlAsync(string webhookUrl, CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new SetPartnerWebhookUrlRequest(_partnerInfo.PartnerId, webhookUrl), cancellationToken);
        }

        public async Task<GetPartnerWhatsAppBusinessApiTemplatesResponse> GetPartnerWhatsAppBusinessApiTemplatesAsync(string whatsAppBusinessApiAccountId, int limit = 1000, int offset = 0, string sort = null, GetPartnerWhatsAppBusinessApiTemplatesFilter filters = null, CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new GetPartnerWhatsAppBusinessApiTemplatesRequest(_partnerInfo.PartnerId, whatsAppBusinessApiAccountId, limit, offset, sort, filters), cancellationToken);
        }

        public async Task<RemovePartnerWhatsAppBusinessApiTemplatesResponse> RemovePartnerWhatsAppBusinessApiTemplatesAsync(string whatsAppBusinessApiAccountId, string templateId, CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new RemovePartnerWhatsAppBusinessApiTemplatesRequest(_partnerInfo.PartnerId, whatsAppBusinessApiAccountId, templateId), cancellationToken);
        }

        public async Task<SetCancellationRequestOnChannelResponse> SetCancellationRequestOnChannelAsync(string clientId, string channelId, bool enabled, CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new SetCancellationRequestOnChannelRequest(_partnerInfo.PartnerId, clientId, channelId, enabled), cancellationToken);
        }

        public async Task<UpdateClientResponse> UpdateClientAsync(string clientId, string partnerPayload, int? maxChannels = null, CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new UpdateClientRequest(_partnerInfo.PartnerId, clientId, partnerPayload, maxChannels), cancellationToken);
        }

        public async Task<GetApiKeyByChannelResponse> GetApiKeyByChannelAsync(string clientId, CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new GetApiKeyByChannelRequest(_partnerInfo.PartnerId, clientId), cancellationToken);
        }

        public async Task<CreateApiKeyByChannelResponse> CreateApiKeyByChannelAsync(string clientId, CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new CreateApiKeyByChannelRequest(_partnerInfo.PartnerId, clientId), cancellationToken);
        }

        public async Task<GetPartnerPublicDataResponse> GetPartnerPublicDataAsync(CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new GetPartnerPublicDataRequest(_partnerInfo.PartnerId), cancellationToken);
        }

        public async Task<PatchPartnerPublicDataResponse> PatchPartnerPublicDataAsync(string webhookUrl, string partnerRedirectUrl, CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new PatchPartnerPublicDataRequest(_partnerInfo.PartnerId, webhookUrl, partnerRedirectUrl), cancellationToken);
        }

        public async Task<DeleteApiKeyByChannelResponse> DeleteApiKeyByChannelAsync(string clientId, CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new DeleteApiKeyByChannelRequest(_partnerInfo.PartnerId, clientId), cancellationToken);
        }

        public async Task<TokenResponse> RequestOAuthTokenAsync(string username, string password, CancellationToken cancellationToken = default)
        {
            return await MakeHttpNoTokenRequestAsync(new TokenRequest(username, password), cancellationToken);
        }

        protected virtual async Task AuthorizeClient(CancellationToken cancellationToken = default)
        {
            var oauthTokenResponse = await RequestOAuthTokenAsync(_partnerInfo.Username, _partnerInfo.Password, cancellationToken);

            _accessToken = oauthTokenResponse.AccessToken;
        }

        protected virtual async Task<TResponse> MakeHttpRequestAsync<TResponse>(PartnerApiRequestBase<TResponse> request, CancellationToken cancellationToken = default) where TResponse : PartnerApiResponseBase, new()
        {
            if (string.IsNullOrEmpty(_accessToken))
                await AuthorizeClient(cancellationToken);

            var requestPath = BasePath + request.MethodName;
            var urlBuilder = new UriBuilder(requestPath);

            if (request.QueryParams != null)
            {
                // Add Query String
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

            httpRequestMessage.Headers.Add("Authorization", $"Bearer {_accessToken}");

            var httpResponse = await HttpClient.SendAsync(httpRequestMessage, cancellationToken);

            var responseAsString = await httpResponse.Content.ReadAsStringAsync();

            JsonHelper.TryDeserializeJson<TResponse>(responseAsString, out var response);

            if (!httpResponse.IsSuccessStatusCode && response != null)
            {
                // Handle Authentication Error
                if (httpResponse.StatusCode == HttpStatusCode.Unauthorized)
                {
                    if (!string.IsNullOrEmpty(_partnerInfo.Username) && !string.IsNullOrEmpty(_partnerInfo.Password))
                    {
                        await AuthorizeClient(cancellationToken);

                        return await MakeHttpRequestAsync(request, cancellationToken);
                    }

                    throw new PartnerClientAuthenticationException(response.Meta.DeveloperMessage, "", urlBuilder.ToString(), (int)httpResponse.StatusCode, await request.ToHttpContent().ReadAsStringAsync());
                }

                throw new PartnerClientException(response?.ErrorDescription, urlBuilder.ToString(), (int)httpResponse.StatusCode, await request.ToHttpContent().ReadAsStringAsync(), responseAsString);
            }

            if (response == null)
                throw new PartnerClientException("360Dialog API Error Occured.", urlBuilder.ToString(), (int)httpResponse.StatusCode, await request.ToHttpContent().ReadAsStringAsync(), responseAsString);

            response.ResponseBody = responseAsString;

            return response;
        }

        protected virtual async Task<TResponse> MakeHttpNoTokenRequestAsync<TResponse>(PartnerApiRequestBase<TResponse> request, CancellationToken cancellationToken = default) where TResponse : PartnerApiResponseBase, new()
        {
            using var client = new HttpClient();

            var requestPath = BasePath + request.MethodName;
            var urlBuilder = new UriBuilder(requestPath);

            if (request.QueryParams != null)
            {
                // Add Query String
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

            var httpResponse = await client.SendAsync(httpRequestMessage, cancellationToken);

            var responseAsString = await httpResponse.Content.ReadAsStringAsync();
            JsonHelper.TryDeserializeJson<TResponse>(responseAsString, out var response);

            if (!httpResponse.IsSuccessStatusCode && response != null)
                throw new PartnerClientAuthenticationException(response.Error, response.ErrorDescription, urlBuilder.ToString(), (int)httpResponse.StatusCode, await request.ToHttpContent().ReadAsStringAsync());

            if (response == null)
                throw new PartnerClientException("360Dialog API Error Occured.", urlBuilder.ToString(), (int)httpResponse.StatusCode, await request.ToHttpContent().ReadAsStringAsync(), responseAsString);

            return response;
        }

        public void Dispose()
        {
            HttpClient.Dispose();
        }
    }
}