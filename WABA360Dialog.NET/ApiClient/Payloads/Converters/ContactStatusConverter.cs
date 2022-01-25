using System.Collections.Generic;
using WABA360Dialog.ApiClient.Payloads.Enums;
using WABA360Dialog.Common.Converters.Base;

namespace WABA360Dialog.ApiClient.Payloads.Converters
{
    internal class ContactStatusConverter : EnumConverter<ContactStatus>
    {
        protected override ContactStatus GetEnumValue(string value) =>
            EnumStringConverter.GetContactStatus(value);

        protected override string GetStringValue(ContactStatus value) =>
            value.GetString();
    }

    public static partial class EnumStringConverter
    {
        private static readonly IReadOnlyDictionary<string, ContactStatus> ContactStatusStringToEnum =
            new Dictionary<string, ContactStatus>
            {
                { "processing", ContactStatus.processing },
                { "valid", ContactStatus.valid },
                { "invalid", ContactStatus.invalid },
                { "failed", ContactStatus.failed },
            };
        
        private static readonly IReadOnlyDictionary<ContactStatus, string> ContactStatusEnumToString =
            new Dictionary<ContactStatus, string>
            {
                { ContactStatus.processing, "processing" },
                { ContactStatus.valid, "valid" },
                { ContactStatus.invalid, "invalid" },
                { ContactStatus.failed, "failed" },
            };

        public static string GetString(this ContactStatus status) =>
            ContactStatusEnumToString.TryGetValue(status, out var stringValue)
                ? stringValue
                : "unknown";

        public static ContactStatus GetContactStatus(string status) =>
            ContactStatusStringToEnum.TryGetValue(status, out var enumValue)
                ? enumValue
                : 0;
    }
}