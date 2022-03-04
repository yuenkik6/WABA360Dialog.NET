using System.Collections.Generic;
using WABA360Dialog.ApiClient.Payloads.Models;
using WABA360Dialog.ApiClient.Payloads.Models.Common;
using WABA360Dialog.PartnerClient.Payloads.Models;

namespace WABA360Dialog.Common.Interfaces
{
    public interface IPartnerApiResponse
    {
        PartnerApiMeta Meta { get; }
        string ResponseBody { get; }
    }

    public interface IClientApiResponse
    {
        ClientApiMeta Meta { get; }
        IEnumerable<ErrorObject> Error { get; }
        string ResponseBody { get; }
    }
}