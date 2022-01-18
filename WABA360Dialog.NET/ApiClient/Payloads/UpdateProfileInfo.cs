using System.Net.Http;
using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Base;

namespace WABA360Dialog.ApiClient.Payloads
{
    public class UpdateProfileInfoAboutTextRequest : ClientApiRequestBase<UpdateProfileInfoAboutTextResponse>
    {
        public UpdateProfileInfoAboutTextRequest(string aboutText) : base("v1/settings/profile/about", new HttpMethod("PATCH"))
        {
            AboutText = aboutText;

        }
        
        [JsonProperty("text")]
        public string AboutText { get; }
    }
    
    public class UpdateProfileInfoAboutTextResponse : ClientApiResponseBase
    {
    }
}