using System.Collections.Generic;
using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.InteractiveObjects
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class SectionObject
    {
        /// <summary>
        /// Required if the message has more than one section.
        /// Title of the section.
        /// Maximum length: 24 characters.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Required for List Messages.
        /// Contains a list of rows.
        /// Each row must have a title (Maximum length: 24 characters) and an ID (Maximum length: 200 characters). You can add a description (Maximum length: 72 characters), but it is optional.
        /// </summary>
        [JsonProperty("product_items")]
        public IEnumerable<ProductObject> ProductItems { get; set; }

        /// <summary>
        /// Required for Multi-Product Messages.
        /// Array of product objects. There is a minimum of 1 product per section. There is a maximum of 30 products across all sections.
        /// </summary>
        [JsonProperty("rows")]
        public IEnumerable<RowsObject> Rows { get; set; }
    }
}