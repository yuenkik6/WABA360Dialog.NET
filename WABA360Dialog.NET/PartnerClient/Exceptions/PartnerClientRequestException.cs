namespace WABA360Dialog.PartnerClient.Exceptions
{
    public class PartnerClientRequestException : PartnerClientExceptionBase
    {
        public string DeveloperMessage { get; set; }

        public PartnerClientRequestException(
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