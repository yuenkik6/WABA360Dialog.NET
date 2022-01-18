using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Enums;

namespace WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.InteractiveObjects
{
    public class ButtonObject
    {
        /// <summary>
        /// Required.
        /// only supported type is reply (for Reply Button Messages)
        /// </summary>
        [JsonProperty("type")]
        public ButtonType Type { get; set; }

        [JsonProperty("reply")]
        public ReplyObject Reply { get; set; }
    }

    public class ButtonTypeObject
    {
        /// <summary>
        /// Required.
        /// only supported type is reply (for Reply Button Messages)
        /// </summary>
        [JsonProperty("type")]
        public ButtonType Type { get; set; }

        /// <summary>
        /// Required.
        /// only supported type is reply (for Reply Button Messages)
        /// </summary>
        [JsonProperty("sub_type")]
        public string SubType { get; set; }

        /// <summary>
        /// Required.
        /// Type of button being created.
        /// Values: quick_reply, url
        /// </summary>
        [JsonProperty("index")]
        public int Index { get; set; }

        [JsonProperty("reply")]
        public ReplyObject Reply { get; set; }
    }
}