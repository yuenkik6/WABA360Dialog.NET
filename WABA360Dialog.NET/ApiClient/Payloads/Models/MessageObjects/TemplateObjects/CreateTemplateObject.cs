using System.Collections.Generic;
using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Enums;
using WABA360Dialog.Common.Enums;

namespace WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.TemplateObjects
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CreateTemplateObject
    {
        /// <summary>
        /// Required.
        /// The type of message template.
        /// </summary>
        [JsonProperty("category")]
        public string Category { get; set; }

        /// <summary>
        /// Required.
        /// The name of the message template.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Required.
        /// The language of the message template
        /// </summary>
        [JsonProperty("language")]
        public WhatsAppLanguage Language { get; set; }

        /// <summary>
        /// Optional.
        /// Array of components objects containing the parameters of the message.
        /// </summary>
        [JsonProperty("components")]
        public IEnumerable<TemplateComponentObject> Components { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class TemplateComponentObject
    {
        [JsonProperty("type")]
        public TemplateComponentType Type { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("example")]
        public object Example { get; set; }

        [JsonProperty("buttons")]
        public IEnumerable<TemplateButtonObject> Buttons { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class TemplateButtonObject
    {
        [JsonProperty("type")]
        public TemplateButtonType Type { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("example")]
        public object Example { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
    }

}