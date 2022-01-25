using System.Collections.Generic;
using WABA360Dialog.ApiClient.Payloads.Enums;
using WABA360Dialog.Common.Converters.Base;

namespace WABA360Dialog.ApiClient.Payloads.Converters
{
    internal class MessageStatusConverter : EnumConverter<MessageStatus>
    {
        protected override MessageStatus GetEnumValue(string value) =>
            EnumStringConverter.GetMessageStatus(value);

        protected override string GetStringValue(MessageStatus value) =>
            value.GetString();
    }
    
    public static partial class EnumStringConverter
    {
        private static readonly IReadOnlyDictionary<string, MessageStatus> MessageStatusStringToEnum =
            new Dictionary<string, MessageStatus>
            {
                { "delivered", MessageStatus.delivered },
                { "read", MessageStatus.read },
                { "sent", MessageStatus.sent },
                { "failed", MessageStatus.failed },
                { "deleted", MessageStatus.deleted },
            };


        private static readonly IReadOnlyDictionary<MessageStatus, string> MessageStatusEnumToString =
            new Dictionary<MessageStatus, string>
            {
                { MessageStatus.delivered, "delivered" },
                { MessageStatus.read, "read" },
                { MessageStatus.sent, "sent" },
                { MessageStatus.failed, "failed" },
                { MessageStatus.deleted, "deleted" },
            };

        public static string GetString(this MessageStatus status) =>
            MessageStatusEnumToString.TryGetValue(status, out var stringValue)
                ? stringValue
                : "unknown";

        public static MessageStatus GetMessageStatus(string status) =>
            MessageStatusStringToEnum.TryGetValue(status, out var enumValue)
                ? enumValue
                : 0;
    }
}