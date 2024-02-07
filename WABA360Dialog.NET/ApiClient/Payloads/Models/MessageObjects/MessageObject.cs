using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Base.Models;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.HsmObjects;

namespace WABA360Dialog.ApiClient.Payloads.Models.MessageObjects
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class MessageObject : AbstractMessageObject
    {      
        /// <summary>
        /// Only used with messages of text type.
        /// Allows for URL previews in text messages. For more information, see the Sending URLs in Text Messages.
        /// This field is optional if not including a URL in your message.
        /// Values: false (default), true
        /// </summary>
        [JsonProperty("preview_url")]
        public bool? PreviewUrl { get; set; }

        /// <summary>
        /// Only used with message templates.
        /// Contains an hsm object. This option will be deprecated when we launch the WhatsApp Business API v2.39. Use the template object instead.
        /// </summary>
        [JsonProperty("hsm")]
        public HsmObject Hsm { get; set; }
    }
}