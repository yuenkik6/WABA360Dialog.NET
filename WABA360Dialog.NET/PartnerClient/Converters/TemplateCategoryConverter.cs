using System.Collections.Generic;
using WABA360Dialog.Common.Converters.Base;
using WABA360Dialog.PartnerClient.Payloads.Enums;

namespace WABA360Dialog.PartnerClient.Converters
{
    internal class TemplateCategoryConverter : EnumConverter<TemplateCategory>
    {
        protected override TemplateCategory GetEnumValue(string value) =>
            EnumStringConverter.GetTemplateCategory(value);

        protected override string GetStringValue(TemplateCategory value) =>
            value.GetString();
    }

    public static partial class EnumStringConverter
    {
        private static readonly IReadOnlyDictionary<string, TemplateCategory> TemplateCategoryStringToEnum =
            new Dictionary<string, TemplateCategory>
            {
                { "unknown", TemplateCategory.unknown },
                { "ACCOUNT_UPDATE", TemplateCategory.ACCOUNT_UPDATE },
                { "PAYMENT_UPDATE", TemplateCategory.PAYMENT_UPDATE },
                { "PERSONAL_FINANCE_UPDATE", TemplateCategory.PERSONAL_FINANCE_UPDATE },
                { "SHIPPING_UPDATE", TemplateCategory.SHIPPING_UPDATE },
                { "RESERVATION_UPDATE", TemplateCategory.RESERVATION_UPDATE },
                { "ISSUE_RESOLUTION", TemplateCategory.ISSUE_RESOLUTION },
                { "APPOINTMENT_UPDATE", TemplateCategory.APPOINTMENT_UPDATE },
                { "TRANSPORTATION_UPDATE", TemplateCategory.TRANSPORTATION_UPDATE },
                { "TICKET_UPDATE", TemplateCategory.TICKET_UPDATE },
                { "ALERT_UPDATE", TemplateCategory.ALERT_UPDATE },
                { "AUTO_REPLY", TemplateCategory.AUTO_REPLY },
            };

        private static readonly IReadOnlyDictionary<TemplateCategory, string> TemplateCategoryEnumToString =
            new Dictionary<TemplateCategory, string>
            {
                { TemplateCategory.unknown, "unknown" },
                { TemplateCategory.ACCOUNT_UPDATE, "ACCOUNT_UPDATE" },
                { TemplateCategory.PAYMENT_UPDATE, "PAYMENT_UPDATE" },
                { TemplateCategory.PERSONAL_FINANCE_UPDATE, "PERSONAL_FINANCE_UPDATE" },
                { TemplateCategory.SHIPPING_UPDATE, "SHIPPING_UPDATE" },
                { TemplateCategory.RESERVATION_UPDATE, "RESERVATION_UPDATE" },
                { TemplateCategory.ISSUE_RESOLUTION, "ISSUE_RESOLUTION" },
                { TemplateCategory.APPOINTMENT_UPDATE, "APPOINTMENT_UPDATE" },
                { TemplateCategory.TRANSPORTATION_UPDATE, "TRANSPORTATION_UPDATE" },
                { TemplateCategory.TICKET_UPDATE, "TICKET_UPDATE" },
                { TemplateCategory.ALERT_UPDATE, "ALERT_UPDATE" },
                { TemplateCategory.AUTO_REPLY, "AUTO_REPLY" },
            };

        public static string GetString(this TemplateCategory status) =>
            TemplateCategoryEnumToString.TryGetValue(status, out var stringValue)
                ? stringValue
                : "unknown";

        public static TemplateCategory GetTemplateCategory(string status) =>
            TemplateCategoryStringToEnum.TryGetValue(status, out var enumValue)
                ? enumValue
                : 0;
    }
}