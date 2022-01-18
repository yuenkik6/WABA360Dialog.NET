using System;

namespace WABA360Dialog.ApiClient.Exceptions
{
    public abstract class ApiClientExceptionBase : Exception
    {
        public string RequestPath { get; }
        public string RequestBody { get; }
        public int HttpStatusCode { get; }
        public string ResponseBody { get; }

        public ApiClientExceptionBase(
            string requestPath,
            int httpStatusCode,
            string requestBody,
            string responseBody) : base($"360Dialog API call failed with code: {httpStatusCode}, Response Body {responseBody}")
        {
            RequestPath = requestPath;
            HttpStatusCode = httpStatusCode;
            ResponseBody = responseBody;
            RequestBody = requestBody;
        }

        public override string ToString()
        {
            return $"360Dialog API call failed at Request at '{RequestPath}', Response Status Code: {HttpStatusCode}\n" +
                   $"Request Body: {RequestBody}\n" +
                   $"Response Body: {ResponseBody}";
        }
    }
}