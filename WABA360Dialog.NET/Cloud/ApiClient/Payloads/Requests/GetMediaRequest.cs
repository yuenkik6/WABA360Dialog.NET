using System.Collections.Generic;
using System.Net.Http;
using WABA360Dialog.Cloud.ApiClient.Payloads.Responses;

namespace WABA360Dialog.Cloud.ApiClient.Payloads.Requests
{
    public class GetMediaRequest : WABA360Dialog.ApiClient.Payloads.Base.ClientApiRequestBase<GetMediaResponse>
    {
        public GetMediaRequest(string relativeUrlPath, Dictionary<string, string> queryParams) : base(relativeUrlPath, HttpMethod.Get, queryParams)
        {
            
        }

        public GetMediaRequest(string relativeUrlPath) : base(HttpMethod.Get)
        {
            var urlParts = relativeUrlPath.Split(new[] { '?', '&' }, System.StringSplitOptions.RemoveEmptyEntries);
            MethodName = urlParts[0];

            if (urlParts.Length > 0)
            {
                var queryParams = new Dictionary<string, string>();
                for (var index = 1; index < urlParts.Length; index++)
                {
                    var parameter = urlParts[index].Split('=');
                    queryParams.Add(parameter[0], parameter[1]);
                }

                QueryParams = queryParams;
            }
        }
    }
}