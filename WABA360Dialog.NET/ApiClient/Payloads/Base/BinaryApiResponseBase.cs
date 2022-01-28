namespace WABA360Dialog.ApiClient.Payloads.Base
{
    public abstract class BinaryApiResponseBase : ClientApiResponseBase
    {
        public byte[] FileBytes { get; set; }
        public string Filename { get; set; }
        public string ContentType { get; set; }
        public long ContentLength { get; set; }
    }
}