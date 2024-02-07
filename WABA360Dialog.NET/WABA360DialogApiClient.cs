using System.Net.Http;
using WABA360Dialog.ApiClient;

namespace WABA360Dialog
{
    public class WABA360DialogApiClient : WABA360DialogApiClientBase
    {
        public const string BASEURL = "https://waba.360dialog.io/";
        public WABA360DialogApiClient(string apiKey) : base(apiKey, new HttpClient())
        {
        }

        public WABA360DialogApiClient(string apiKey, HttpClient httpClient) : base(apiKey, httpClient)
        {
        }

        public override string BasePath => BASEURL;
    }
}