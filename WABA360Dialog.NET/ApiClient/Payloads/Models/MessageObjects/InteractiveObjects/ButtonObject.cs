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
}