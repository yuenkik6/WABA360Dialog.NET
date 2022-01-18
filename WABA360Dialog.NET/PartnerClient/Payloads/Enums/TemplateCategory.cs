using Newtonsoft.Json;
using WABA360Dialog.PartnerClient.Converters;

namespace WABA360Dialog.PartnerClient.Payloads.Enums
{
    [JsonConverter(typeof(TemplateCategoryConverter))]
    public enum TemplateCategory
    {
        unknown = 0,
        ACCOUNT_UPDATE = 1,
        PAYMENT_UPDATE = 2,
        PERSONAL_FINANCE_UPDATE = 3,
        SHIPPING_UPDATE = 4,
        RESERVATION_UPDATE = 5,
        ISSUE_RESOLUTION = 6,
        APPOINTMENT_UPDATE = 7,
        TRANSPORTATION_UPDATE = 8,
        TICKET_UPDATE = 9,
        ALERT_UPDATE = 10,
        AUTO_REPLY = 11,
    }
}