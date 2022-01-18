using WABA360Dialog.ApiClient;

namespace WABA360Dialog
{
    public class WABA360DialogApiClient : WABA360DialogApiClientBase
    {
        private const string SandboxClientPath =  "https://waba.360dialog.io/";
        
        public WABA360DialogApiClient(string apiKey) : base(apiKey, SandboxClientPath)
        {
        }
    }
}