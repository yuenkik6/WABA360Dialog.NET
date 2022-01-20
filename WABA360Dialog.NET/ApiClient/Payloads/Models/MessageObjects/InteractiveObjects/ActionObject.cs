using System.Collections.Generic;
using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.InteractiveObjects
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ActionObject
    {
        /// <summary>
        /// Required for List Messages.
        /// Button content. It cannot be an empty string and must be unique within the message Does not allow emojis or markdown.
        /// Maximum length: 20 characters.
        /// </summary>
        [JsonProperty("button")]
        public string Button { get; set; }

        /// <summary>
        /// Required for Reply Button Messages.
        /// </summary>
        [JsonProperty("buttons")]
        public IEnumerable<ButtonObject> Buttons { get; set; }
        
        /// <summary>
        /// Required for List Messages and Multi-Product Messages.
        /// Array of SectionObject. There is a minimum of 1 and maximum of 10. See section object.
        /// </summary>
        [JsonProperty("sections")]
        public IEnumerable<SectionObject> Sections { get; set; }

        /// <summary>
        /// Required for Single Product Messages and Multi-Product Messages.
        /// Unique identifier of the Facebook catalog linked to your WhatsApp Business Account. This ID can be retrieved via Commerce Manager.
        /// </summary>
        [JsonProperty("catalog_id")]
        public string CatalogId { get; set; }

        /// <summary>
        /// Required for Single Product Messages and Multi-Product Messages.
        /// Unique identifier of the product in a catalog.
        /// </summary>
        [JsonProperty("product_retailer_id")]
        public string ProductRetailerId { get; set; }
    }
}