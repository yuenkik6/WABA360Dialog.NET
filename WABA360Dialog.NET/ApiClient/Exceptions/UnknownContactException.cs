namespace WABA360Dialog.ApiClient.Exceptions
{
    public class UnknownContactException : ApiClientExceptionBase
    {
        public UnknownContactException(
            string requestPath,
            int httpStatusCode,
            string requestBody,
            string responseBody)
            : base(requestPath, httpStatusCode, responseBody, requestBody)
        {
        }

    }
}