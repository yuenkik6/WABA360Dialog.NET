using System.Threading;
using System.Threading.Tasks;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.TemplateObjects;
using WABA360Dialog.Common.Enums;
using WABA360Dialog.PartnerClient.Payloads;

namespace WABA360Dialog.PartnerClient.Interfaces
{
    public interface IWABA360DialogPartnerClient
    {
        Task<CreatePartnerWhatsAppBusinessApiTemplateResponse> CreatePartnerWhatsAppBusinessApiTemplateAsync(string whatsAppBusinessApiAccountId, string name, string category, WhatsAppLanguage language, TemplateComponentObject components, CancellationToken cancellationToken = default);
        Task<GetClientBalanceResponse> GetClientBalanceAsync(string clientId, int fromMonth, int fromYear, CancellationToken cancellationToken = default);
        Task<GetPartnerChannelsResponse> GetPartnerChannelsAsync(int limit = 20, int offset = 0, string sort = null, GetPartnerChannelsFilter filters = null, CancellationToken cancellationToken = default);
        Task<GetPartnerClientsResponse> GetPartnerClientsAsync(int limit = 20, int offset = 0, string sort = null, GetPartnerClientsFilter filters = null, CancellationToken cancellationToken = default);
        Task<GetPartnerWebhookUrlResponse> GetPartnerWebhookUrlAsync(CancellationToken cancellationToken = default);
        Task<SetPartnerWebhookUrlResponse> SetPartnerWebhookUrlAsync(string webhookUrl, CancellationToken cancellationToken = default);
        Task<GetPartnerWhatsAppBusinessApiTemplatesResponse> GetPartnerWhatsAppBusinessApiTemplatesAsync(string whatsAppBusinessApiAccountId, int limit = 1000, int offset = 0, string sort = null, GetPartnerWhatsAppBusinessApiTemplatesFilter filters = null, CancellationToken cancellationToken = default);
        Task<RemovePartnerWhatsAppBusinessApiTemplatesResponse> RemovePartnerWhatsAppBusinessApiTemplatesAsync(string whatsAppBusinessApiAccountId, string templateId, CancellationToken cancellationToken = default);
        Task<SetCancellationRequestOnChannelResponse> SetCancellationRequestOnChannelAsync(string clientId, string channelId, bool enabled, CancellationToken cancellationToken = default);
        Task<UpdateClientResponse> UpdateClientAsync(string clientId, string partnerPayload, int? maxChannels = null, CancellationToken cancellationToken = default);
        Task<GetApiKeyByChannelResponse> GetApiKeyByChannelAsync(string clientId, CancellationToken cancellationToken = default);
        Task<CreateApiKeyByChannelResponse> CreateApiKeyByChannelAsync(string clientId, CancellationToken cancellationToken = default);
        Task<GetPartnerPublicDataResponse> GetPartnerPublicDataAsync(CancellationToken cancellationToken = default);
        Task<PatchPartnerPublicDataResponse> PatchPartnerPublicDataAsync(string webhookUrl, string partnerRedirectUrl, CancellationToken cancellationToken = default);
        Task<DeleteApiKeyByChannelResponse> DeleteApiKeyByChannelAsync(string clientId, CancellationToken cancellationToken = default);
        Task<TokenResponse> RequestOAuthTokenAsync(string username, string password, CancellationToken cancellationToken = default);
    }
}