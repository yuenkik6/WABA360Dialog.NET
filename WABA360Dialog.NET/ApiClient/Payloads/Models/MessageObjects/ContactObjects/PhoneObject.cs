using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Enums;

namespace WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.ContactObjects
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class PhoneObject
    {
        /// <summary>
        /// Optional.
        /// Automatically populated with the wa_id value as a formatted phone number.
        /// </summary>
        [JsonProperty("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Optional.
        /// Standard Values: CELL, MAIN, IPHONE, HOME, WORK
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Optional.
        /// WhatsApp ID.
        /// </summary>
        [JsonProperty("wa_id")]
        public string WaId { get; set; }
    }
    
}