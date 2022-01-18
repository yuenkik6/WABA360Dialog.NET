using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using WABA360Dialog.Common.Enums;
using WABA360Dialog.PartnerClient.Exceptions;
using WABA360Dialog.PartnerClient.Interfaces;
using WABA360Dialog.PartnerClient.Models;
using WABA360Dialog.PartnerClient.Payloads;
using WABA360Dialog.PartnerClient.Payloads.Base;
using WABA360Dialog.PartnerClient.Payloads.Enums;

namespace WABA360Dialog
{
    public class WABA360DialogPartnerClient : IWABA360DialogPartnerClient
    {
        private const string BasePath = "https://hub.360dialog.io/api/v2/";

        private readonly PartnerInfo _partnerInfo;
        private string _accessToken;

        public WABA360DialogPartnerClient(PartnerInfo partnerInfo)
        {
            if (partnerInfo == null)
                throw new ArgumentNullException(nameof(partnerInfo), "Partner Info cannot be null.");

            if (string.IsNullOrEmpty(partnerInfo.PartnerId) || string.IsNullOrEmpty(partnerInfo.Username) || string.IsNullOrEmpty(partnerInfo.Password))
                throw new ArgumentException("Partner Info cannot be null.");

            _partnerInfo = partnerInfo;
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
        }

        public async Task<CreatePartnerWhatsAppBusinessApiTemplateResponse> CreatePartnerWhatsAppBusinessApiTemplateAsync(
            string whatsAppBusinessApiAccountId,
            string name,
            TemplateCategory category,
            WhatsAppLanguage language,
            object components,
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

        public async Task<GetPartnerChannelsResponse> GetPartnerChannelsAsync(int limit = 20, int offset = 0, string sort = null, object filters = null, CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new GetPartnerChannelsRequest(_partnerInfo.PartnerId, limit, offset, sort, filters), cancellationToken);
        }

        public async Task<GetPartnerClientsResponse> GetPartnerClientsAsync(int limit = 20, int offset = 0, string sort = null, object filters = null, CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new GetPartnerClientsRequest(_partnerInfo.PartnerId, limit, offset, sort, filters), cancellationToken);
        }

        public async Task<GetPartnerWebhookUrlResponse> GetPartnerWebhookUrlAsync(CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new GetPartnerWebhookUrlRequest(_partnerInfo.PartnerId), cancellationToken);
        }

        public async Task<GetPartnerWhatsAppBusinessApiTemplatesResponse> GetPartnerWhatsAppBusinessApiTemplatesAsync(string whatsAppBusinessApiAccountId, int limit = 20, int offset = 0, string sort = null, object filters = null, CancellationToken cancellationToken = default)
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

        public async Task<SetPartnerWebhookUrlResponse> SetPartnerWebhookUrlAsync(string webhookUrl, CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new SetPartnerWebhookUrlRequest(_partnerInfo.PartnerId, webhookUrl), cancellationToken);
        }

        public async Task<UpdateClientResponse> UpdateClientAsync(string clientId, string partnerPayload, CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestAsync(new UpdateClientRequest(_partnerInfo.PartnerId, clientId, partnerPayload), cancellationToken);
        }

        public async Task<TokenResponse> RequestOAuthTokenAsync(string username, string password, CancellationToken cancellationToken = default)
        {
            return await MakeHttpRequestNoTokenAsync(new TokenRequest(username, password), cancellationToken);
        }

        private async Task AuthorizeClient(CancellationToken cancellationToken = default)
        {
            var oauthTokenResponse = await RequestOAuthTokenAsync(_partnerInfo.Username, _partnerInfo.Password, cancellationToken);

            _accessToken = oauthTokenResponse.AccessToken;
        }

        private async Task<TResponse> MakeHttpRequestAsync<TResponse>(PartnerApiRequestBase<TResponse> request, CancellationToken cancellationToken = default) where TResponse : PartnerApiResponseBase
        {
            if (string.IsNullOrEmpty(_accessToken))
                await AuthorizeClient(cancellationToken);

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

            httpRequestMessage.Headers.Add("Authorization", $"Bearer {_accessToken}");

            var httpResponse = await client.SendAsync(httpRequestMessage, cancellationToken);

            var responseAsString = await httpResponse.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<TResponse>(responseAsString);

            if (!httpResponse.IsSuccessStatusCode)
            {
                if (httpResponse.StatusCode == HttpStatusCode.Unauthorized && !string.IsNullOrEmpty(_partnerInfo.Username) && !string.IsNullOrEmpty(_partnerInfo.Password))
                {
                    await AuthorizeClient(cancellationToken);

                    return await MakeHttpRequestAsync(request, cancellationToken);
                }

                throw new PartnerClientRequestException(response?.ErrorDescription, requestPath, (int)httpResponse.StatusCode, await request.ToHttpContent().ReadAsStringAsync(), responseAsString);
            }

            return response;
        }

        private async Task<TResponse> MakeHttpRequestNoTokenAsync<TResponse>(PartnerApiRequestBase<TResponse> request, CancellationToken cancellationToken = default) where TResponse : PartnerApiResponseBase
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
            var response = JsonConvert.DeserializeObject<TResponse>(responseAsString);

            if (!httpResponse.IsSuccessStatusCode)
                throw new PartnerClientAuthenticationException(response?.Error, response?.ErrorDescription, requestPath, (int)httpResponse.StatusCode, await request.ToHttpContent().ReadAsStringAsync());

            return response;
        }
    }
}