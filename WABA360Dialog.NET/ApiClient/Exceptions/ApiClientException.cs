namespace WABA360Dialog.ApiClient.Exceptions
{
    public class ApiClientException : ApiClientExceptionBase
    {
        public ApiClientException(
            string requestPath,
            int httpStatusCode,
            string requestBody,
            string responseBody)
            : base(requestPath, httpStatusCode, responseBody, requestBody)
        {
        }

    }
}