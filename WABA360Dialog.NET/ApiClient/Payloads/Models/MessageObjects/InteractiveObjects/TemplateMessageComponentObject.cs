using System.Collections.Generic;
using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Enums;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.TemplateObjects;

namespace WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.InteractiveObjects
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class TemplateMessageComponentObject
    {
        /// <summary>
        /// Required.
        /// Describes the component type.
        /// Values: header, body, or button. For text-based templates, we only support the type=body.
        /// </summary>
        [JsonProperty("type")]
        public ComponentType Type { get; set; }

        /// <summary>
        /// Optional. Used when type is set to button.
        /// Supported values are:
        /// quick_reply: Refers to a previously created quick reply button that allows for the customer to return a predefined message. See Callback from a Quick Reply Button Click for an example of a response from a quick reply button.
        /// url: Refers to a previously created button that allows the customer to visit the URL generated by appending the text parameter to the predefined prefix URL in the template.
        /// </summary>
        [JsonProperty("sub_type")]
        public ButtonType? SubType { get; set; }
        
        /// <summary>
        /// Optional. Used when type is set to button.
        /// Position index of the button. You can have up to 3 buttons using index values of 0-2.
        /// </summary>
        [JsonProperty("index")]
        public int? Index { get; set; }

        /// <summary>
        /// Optional.
        /// Array of parameter objects with the content of the message.
        /// </summary>
        [JsonProperty("parameters")]
        public IEnumerable<ParameterObject> Parameters { get; set; }
    }
}