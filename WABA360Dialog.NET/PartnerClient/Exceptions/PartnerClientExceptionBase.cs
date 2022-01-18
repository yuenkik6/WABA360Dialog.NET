using System;

namespace WABA360Dialog.PartnerClient.Exceptions
{
    public abstract class PartnerClientExceptionBase : Exception
    {
        public int HttpStatusCode { get; set; }
        public string RequestPath { get; set; }
        public string RequestBody { get; set; }
        public string ResponseBody { get; set; }


        public PartnerClientExceptionBase(
            string message,
            string requestPath,
            int httpStatusCode,
            string requestBody,
            string responseBody) : base(message)
        {
            HttpStatusCode = httpStatusCode;
            RequestPath = requestPath;
            RequestBody = requestBody;
            ResponseBody = responseBody;
        }

        public override string ToString()
        {
            return $"Error Occurred at Request at '{RequestPath}', Response Status Code: {HttpStatusCode}, Message: {Message} \n" +
                   $"Request Body: {RequestBody}\n" +
                   $"Response Body: {ResponseBody}";
        }
    }

}