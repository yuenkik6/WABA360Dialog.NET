using System.Collections.Generic;
using WABA360Dialog.ApiClient.Payloads.Enums;
using WABA360Dialog.Common.Converters.Base;

namespace WABA360Dialog.ApiClient.Payloads.Models.Converters
{
    internal class InteractiveReplyTypeConverter : EnumConverter<InteractiveReplyType>
    {
        protected override InteractiveReplyType GetEnumValue(string value) =>
            EnumStringConverter.GetInteractiveReplyType(value);

        protected override string GetStringValue(InteractiveReplyType value) =>
            value.GetString();
    }
    
    public static partial class EnumStringConverter
    {
        private static readonly IReadOnlyDictionary<string, InteractiveReplyType> InteractiveReplyTypeStringToEnum =
            new Dictionary<string, InteractiveReplyType>
            {
                { "button_reply", InteractiveReplyType.button_reply },
                { "list_reply", InteractiveReplyType.list_reply },
            };


        private static readonly IReadOnlyDictionary<InteractiveReplyType, string> InteractiveReplyTypeEnumToString =
            new Dictionary<InteractiveReplyType, string>
            {
                { InteractiveReplyType.button_reply, "button_reply" },
                { InteractiveReplyType.list_reply, "list_reply" },
            };

        public static string GetString(this InteractiveReplyType status) =>
            InteractiveReplyTypeEnumToString.TryGetValue(status, out var stringValue)
                ? stringValue
                : "unknown";

        public static InteractiveReplyType GetInteractiveReplyType(string status) =>
            InteractiveReplyTypeStringToEnum.TryGetValue(status, out var enumValue)
                ? enumValue
                : 0;
    }
}