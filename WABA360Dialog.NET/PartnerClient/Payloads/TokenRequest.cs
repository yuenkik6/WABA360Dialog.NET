using System.Net.Http;
using Newtonsoft.Json;
using WABA360Dialog.PartnerClient.Payloads.Base;

namespace WABA360Dialog.PartnerClient.Payloads
{
    public class TokenRequest : PartnerApiRequestBase<TokenResponse>
    {
        public TokenRequest(string username, string password) : base("token", HttpMethod.Post)
        {
            Username = username;
            Password = password;
        }

        [JsonProperty("username")]
        public string Username { get; set; }
        
        [JsonProperty("password")]
        public string Password { get; set; }
    }

    public class TokenResponse : PartnerApiResponseBase
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
    }
}