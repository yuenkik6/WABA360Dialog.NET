namespace WABA360Dialog.ApiClient.Payloads.Base
{
    public abstract class BinaryApiResponseBase : ClientApiResponseBase
    {
        public byte[] FileBytes { get; set; }
    }
}