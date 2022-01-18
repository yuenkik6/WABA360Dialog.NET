using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.ContactObjects
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class OrgObject
    {
        /// <summary>
        /// Optional.
        /// Name of the contact's company.
        /// </summary>
        [JsonProperty("company")]
        public string Company { get; set; }

        /// <summary>
        /// Optional.
        /// Contact's business title.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Optional.
        /// Name of the contact's department.
        /// </summary>
        [JsonProperty("department")]
        public string Department { get; set; }
    }
}