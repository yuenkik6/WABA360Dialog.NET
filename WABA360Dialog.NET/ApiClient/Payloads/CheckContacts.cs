using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Base;
using WABA360Dialog.ApiClient.Payloads.Enums;
using WABA360Dialog.ApiClient.Payloads.Models;

namespace WABA360Dialog.ApiClient.Payloads
{
    public class CheckContactsRequest : ClientApiRequestBase<CheckContactsResponse>
    {
        public CheckContactsRequest(IEnumerable<string> contacts, Blocking blocking = Blocking.no_wait, bool forceCheck = false) : base("v1/contacts", HttpMethod.Post)
        {
            Contacts = contacts;
            Blocking = blocking;
            ForceCheck = forceCheck;
        }

        [JsonProperty("contacts")]
        public IEnumerable<string> Contacts { get; }

        [JsonProperty("blocking")]
        public Blocking Blocking { get; }

        [JsonProperty("force_check")]
        public bool ForceCheck { get; }
    }

    public class CheckContactsResponse : ClientApiResponseBase
    {
        [JsonProperty("contacts")]
        public IEnumerable<CheckContactResult> Contacts { get; set; }
    }
}