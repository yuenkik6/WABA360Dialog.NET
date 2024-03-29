﻿using System.Collections.Generic;
using WABA360Dialog.ApiClient.Payloads.Models;
using WABA360Dialog.ApiClient.Payloads.Models.Common;

namespace WABA360Dialog.ApiClient.Exceptions
{
    public class ApiClientException : ApiClientExceptionBase
    {

        public ApiClientException(IEnumerable<ErrorObject> error,
            ClientApiMeta meta,
            string requestPath,
            int httpStatusCode,
            string requestBody,
            string responseBody)
            : base(requestPath, httpStatusCode, requestBody, responseBody)
        {
            Error = error;
            Meta = meta;
        }

        public ApiClientException(
            string requestPath,
            int httpStatusCode,
            string requestBody,
            string responseBody)
            : base(requestPath, httpStatusCode, requestBody, responseBody)
        {
        }

        public IEnumerable<ErrorObject> Error { get; }
        public ClientApiMeta Meta { get; }
    }
}