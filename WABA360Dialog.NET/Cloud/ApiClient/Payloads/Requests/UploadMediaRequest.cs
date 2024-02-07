using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using WABA360Dialog.Cloud.ApiClient.Payloads.Enums;
using WABA360Dialog.Cloud.ApiClient.Payloads.Responses;

namespace WABA360Dialog.Cloud.ApiClient.Payloads.Requests
{
    public class UploadMediaRequest : WABA360Dialog.ApiClient.Payloads.Base.ClientApiRequestBase<UploadMediaResponse>
    {
        public UploadMediaRequest(string fileName, byte[] fileBytes, string contentType) : base("media", HttpMethod.Post)
        {
            FileName = fileName;
            FileBytes = fileBytes;
            ContentType = contentType;
        }

        public string FileName { get; }
        public byte[] FileBytes { get; }
        public string ContentType { get; }

        public override HttpContent ToHttpContent()
        {
            var fileContent = new ByteArrayContent(FileBytes);
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(ContentType);
            
            var content = new MultipartFormDataContent
            {
                { new StringContent(MessagingProduct.whatsapp.ToString()), "messaging_product" },
                { fileContent, "file", FileName }
            };

            return content;
        }
    }
}