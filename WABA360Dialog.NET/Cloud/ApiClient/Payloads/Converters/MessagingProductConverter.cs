using System.Collections.Generic;
using WABA360Dialog.Cloud.ApiClient.Payloads.Enums;
using WABA360Dialog.Common.Converters.Base;

namespace WABA360Dialog.Cloud.ApiClient.Payloads.Converters
{
    internal class MessagingProductConverter : EnumConverter<MessagingProduct>
    {
        protected override MessagingProduct GetEnumValue(string value)
        {
            return EnumStringConverter.GetMessagingProduct(value);
        }

        protected override string GetStringValue(MessagingProduct value)
        {
            return value.GetString();
        }
    }
        public static partial class EnumStringConverter
    {
        private static readonly IReadOnlyDictionary<string, MessagingProduct> MessagingProductStringToEnum =
            new Dictionary<string, MessagingProduct>
            {
                { "unknown", MessagingProduct.unknown },
                { "whatsapp", MessagingProduct.whatsapp },
            };

        private static readonly IReadOnlyDictionary<MessagingProduct, string> MessagingProductEnumToString =
            new Dictionary<MessagingProduct, string>
            {
                { MessagingProduct.unknown, "unknown" },
                { MessagingProduct.whatsapp, "whatsapp" }
            };

        public static string GetString(this MessagingProduct status)
        {
            return MessagingProductEnumToString.TryGetValue(status, out var stringValue)
                ? stringValue
                : "unknown";
        }

        public static MessagingProduct GetMessagingProduct(string status)
        {
            return MessagingProductStringToEnum.TryGetValue(status, out var enumValue)
                ? enumValue
                : 0;
        }
    }
}