namespace WABA360Dialog.PartnerClient.Exceptions
{
    public class PartnerClientException : PartnerClientExceptionBase
    {
        public string DeveloperMessage { get; }

        public PartnerClientException(
            string developerMessage,
            string requestPath,
            int httpStatusCode,
            string requestBody,
            string responseBody
        ) : base(developerMessage, requestPath, httpStatusCode, requestBody, responseBody)
        {
            DeveloperMessage = developerMessage;
        }
    }
}