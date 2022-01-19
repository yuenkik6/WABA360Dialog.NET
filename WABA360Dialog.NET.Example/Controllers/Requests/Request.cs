using System.Collections.Generic;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.InteractiveObjects;
using WABA360Dialog.Common.Enums;

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
        List<ComponentObject> Components);

    public record SetWabaWebhookRequest(string Url, string HeaderName, string HeaderValue);

    public record SetPartnerWebhookRequest(string Url);

    public record GetClientBalanceRequest(string ClientId, int FromMonth, int FromYear);
}
