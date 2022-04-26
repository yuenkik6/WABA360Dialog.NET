using System.Collections.Generic;
using Newtonsoft.Json;
using WABA360Dialog.Common.Converters.Base;

namespace WABA360Dialog.ApiClient.Payloads.Enums
{
    [JsonConverter(typeof(MessageTypeConverter))]
    public enum MessageType
    {
        unknown = 0,
        text = 1,
        audio = 2,
        video = 3,
        contacts = 4,
        document = 5,
        image = 6,
        location = 7,
        sticker = 8,
        template = 9,
        interactive = 10,
        button = 11,
        hsm = 12,
    }

    internal class MessageTypeConverter : EnumConverter<MessageType>
    {
        protected override MessageType GetEnumValue(string value)
        {
            return EnumStringConverter.GetMessageType(value);
        }

        protected override string GetStringValue(MessageType value)
        {
            return value.GetString();
        }
    }

    public static partial class EnumStringConverter
    {
        private static readonly IReadOnlyDictionary<string, MessageType> MessageTypeStringToEnum =
            new Dictionary<string, MessageType>
            {
                { "unknown", MessageType.unknown },
                { "audio", MessageType.audio },
                { "contacts", MessageType.contacts },
                { "document", MessageType.document },
                { "image", MessageType.image },
                { "location", MessageType.location },
                { "sticker", MessageType.sticker },
                { "template", MessageType.template },
                { "text", MessageType.text },
                { "video", MessageType.video },
                { "interactive", MessageType.interactive },
                { "button", MessageType.button },
                { "hsm", MessageType.hsm },
            };

        private static readonly IReadOnlyDictionary<MessageType, string> MessageTypeEnumToString =
            new Dictionary<MessageType, string>
            {
                { MessageType.audio, "audio" },
                { MessageType.contacts, "contacts" },
                { MessageType.document, "document" },
                { MessageType.image, "image" },
                { MessageType.location, "location" },
                { MessageType.sticker, "sticker" },
                { MessageType.template, "template" },
                { MessageType.text, "text" },
                { MessageType.video, "video" },
                { MessageType.interactive, "interactive" },
                { MessageType.button, "button" },
                { MessageType.hsm, "hsm" },
            };

        public static string GetString(this MessageType status)
        {
            return MessageTypeEnumToString.TryGetValue(status, out var stringValue)
                ? stringValue
                : "unknown";
        }

        public static MessageType GetMessageType(string status)
        {
            return MessageTypeStringToEnum.TryGetValue(status, out var enumValue)
                ? enumValue
                : 0;
        }
    }
}