namespace WABA360Dialog.PartnerClient.Exceptions
{
    public class PartnerClientAuthenticationException : PartnerClientExceptionBase
    {
        public string Error { get; set; }
        public string ErrorDescription { get; set; }

        public PartnerClientAuthenticationException(
            string error,
            string errorDescription,
            string requestPath,
            int httpStatusCode,
            string responseBody) : base(errorDescription, requestPath, httpStatusCode,  "HIDDEN", responseBody)
        {
            Error = error;
            ErrorDescription = errorDescription;
        }

        public override string ToString()
        {
            return $"Authentication failed occurred at Request at '{RequestPath}', Response Status Code: '{HttpStatusCode}',\n" +
                   $"Error: '{Error}' ErrorDescription: '{ErrorDescription}'\n" +
                   $"Response Body: {ResponseBody}";
        }
    }
}