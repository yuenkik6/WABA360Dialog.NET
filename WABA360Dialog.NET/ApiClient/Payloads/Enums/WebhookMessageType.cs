using System.Collections.Generic;
using Newtonsoft.Json;
using WABA360Dialog.Common.Converters.Base;

namespace WABA360Dialog.ApiClient.Payloads.Enums
{
    [JsonConverter(typeof(WebhookMessageTypeConverter))]
    public enum WebhookMessageType
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
        voice = 9,
    }

    internal class WebhookMessageTypeConverter : EnumConverter<MessageType>
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
        private static readonly IReadOnlyDictionary<string, WebhookMessageType> WebhookMessageTypeStringToEnum =
            new Dictionary<string, WebhookMessageType>
            {
                { "unknown", WebhookMessageType.unknown },
                { "text", WebhookMessageType.text },
                { "audio", WebhookMessageType.audio },
                { "video", WebhookMessageType.video },
                { "contacts", WebhookMessageType.contacts },
                { "document", WebhookMessageType.document },
                { "image", WebhookMessageType.image },
                { "location", WebhookMessageType.location },
                { "sticker", WebhookMessageType.sticker },
                { "voice", WebhookMessageType.voice },
            };

        private static readonly IReadOnlyDictionary<WebhookMessageType, string> WebhookMessageTypeEnumToString =
            new Dictionary<WebhookMessageType, string>
            {
                { WebhookMessageType.unknown, "unknown" },
                { WebhookMessageType.text, "text" },
                { WebhookMessageType.audio, "audio" },
                { WebhookMessageType.video, "video" },
                { WebhookMessageType.contacts, "contacts" },
                { WebhookMessageType.document, "document" },
                { WebhookMessageType.image, "image" },
                { WebhookMessageType.location, "location" },
                { WebhookMessageType.sticker, "sticker" },
            };

        public static string GetString(this WebhookMessageType status)
        {
            return WebhookMessageTypeEnumToString.TryGetValue(status, out var stringValue)
                ? stringValue
                : "unknown";
        }

        public static WebhookMessageType GetWebhookMessageType(string status)
        {
            return WebhookMessageTypeStringToEnum.TryGetValue(status, out var enumValue)
                ? enumValue
                : 0;
        }
    }
}