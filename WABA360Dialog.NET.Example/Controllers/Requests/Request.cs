using System.Collections.Generic;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.InteractiveObjects;
using WABA360Dialog.Common.Enums;
using WABA360Dialog.PartnerClient.Payloads;

namespace WABA360Dialog.NET.Example.Controllers.Requests
{
    public record CheckContactRequest(string PhoneNumber);

    public record SendMessageRequest(string WhatsappId, string TextMessage);

    public record SendMediaMessageRequest(string WhatsappId, string Link, string Caption);

    public record SendNoCaptionMediaMessageRequest(string WhatsappId, string Link);

    public record SendDocumentMessageRequest(string WhatsappId, string Link, string Filename, string Caption);

    public record SendTemplateMessageRequest(string WhatsappId,
        string TemplateNamespace,
        string TemplateName,
        WhatsAppLanguage Language,
        List<TemplateMessageComponentObject> Components);

    public record SetWabaWebhookRequest(string Url, string HeaderName, string HeaderValue);

    public record SetPartnerWebhookRequest(string Url);

    public record GetClientBalanceRequest(string ClientId, int FromMonth, int FromYear);
    public record GetPartnerClientsRequest(int Limit = 20, int Offset = 0, string Sort = null, GetPartnerClientsFilter Filters = null);
    public record GetPartnerChannelsRequest(int Limit = 20, int Offset = 0, string Sort = null, GetPartnerChannelsFilter Filters = null);
}
