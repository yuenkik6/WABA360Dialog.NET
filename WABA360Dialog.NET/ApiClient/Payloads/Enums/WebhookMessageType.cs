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
        interactive = 10,
        button = 11,
        order = 12,
        system = 13,
        ephemeral = 14,
    }

    internal class WebhookMessageTypeConverter : EnumConverter<WebhookMessageType>
    {
        protected override WebhookMessageType GetEnumValue(string value)
        {
            return EnumStringConverter.GetWebhookMessageType(value);
        }

        protected override string GetStringValue(WebhookMessageType value)
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
                { "interactive", WebhookMessageType.interactive },
                { "button", WebhookMessageType.button },
                { "order", WebhookMessageType.order },
                { "system", WebhookMessageType.system },
                { "ephemeral", WebhookMessageType.ephemeral },
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
                { WebhookMessageType.voice, "voice" },
                { WebhookMessageType.interactive, "interactive" },
                { WebhookMessageType.button, "button" },
                { WebhookMessageType.order, "order" },
                { WebhookMessageType.system, "system" },
                { WebhookMessageType.ephemeral, "ephemeral" },
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