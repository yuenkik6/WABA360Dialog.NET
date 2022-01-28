using System.Net.Http.Headers;

namespace WABA360Dialog.ApiClient.Payloads.Base
{
    public abstract class BinaryApiResponseBase : ClientApiResponseBase
    {
        public byte[] FileBytes { get; set; }
        public ContentDispositionHeaderValue ContentDisposition { get; set; }
        public MediaTypeHeaderValue ContentType { get; set; }
        public long ContentLength { get; set; }
    }
}