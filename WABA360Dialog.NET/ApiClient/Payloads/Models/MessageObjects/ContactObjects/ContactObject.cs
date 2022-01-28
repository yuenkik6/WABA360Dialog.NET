using System.Collections.Generic;
using Newtonsoft.Json;

namespace WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.ContactObjects
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ContactObject
    {
        /// <summary>
        /// Optional.
        /// Full contact address(es) —see AddressObject.
        /// </summary>
        [JsonProperty("addresses")]
        public IEnumerable<AddressObject> Address { get; set; }

        /// <summary>
        /// Optional.
        /// YYYY-MM-DD formatted string.
        /// </summary>
        [JsonProperty("birthday")]
        public string Birthday { get; set; }

        /// <summary>
        /// Optional.
        /// Contact email address(es) —see EmailObject.
        /// </summary>
        [JsonProperty("emails")]
        public IEnumerable<EmailObject> Email { get; set; }

        /// <summary>
        /// Required.
        /// Full contact name — see NameObject.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Optional.
        /// Contact organization information —see OrgObject.
        /// </summary>
        [JsonProperty("org")]
        public OrgObject Org { get; set; }

        /// <summary>
        /// Optional.
        /// Optional.
        /// Contact phone number(s) —see PhoneObject.
        /// </summary>
        [JsonProperty("phones")]
        public IEnumerable<PhoneObject> Phones { get; set; }

        /// <summary>
        /// Optional.
        /// Contact URL(s) —see UrlObject.
        /// </summary>
        [JsonProperty("urls")]
        public IEnumerable<UrlObject> Urls { get; set; }
    }
}