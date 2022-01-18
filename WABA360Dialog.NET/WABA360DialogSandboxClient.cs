using WABA360Dialog.ApiClient;

namespace WABA360Dialog
{
    public class WABA360DialogSandboxClient : WABA360DialogApiClientBase
    {
        private const string SandboxClientPath = "https://waba-sandbox.360dialog.io/";
        
        public WABA360DialogSandboxClient(string apiKey) : base(apiKey, SandboxClientPath)
        {
        }
    }
}