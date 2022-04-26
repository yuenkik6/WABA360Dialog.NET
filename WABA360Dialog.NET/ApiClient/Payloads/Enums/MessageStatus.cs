using Newtonsoft.Json;
using WABA360Dialog.ApiClient.Payloads.Converters;

namespace WABA360Dialog.ApiClient.Payloads.Enums
{
    [JsonConverter(typeof(MessageStatusConverter))]
    public enum MessageStatus
    {
        /// <summary>
        /// A message sent by your business was delivered to the user's device.
        /// </summary>
        delivered = 1,

        /// <summary>
        /// A message sent by your business was read by the user. read notifications are only available for users that have read receipts enabled. For users that do not have it enabled, you only receive the delivered notification.
        /// </summary>
        read = 2,

        /// <summary>
        /// A message sent by your business is in transit within our systems.
        /// </summary>
        sent = 3,

        /// <summary>
        /// A message sent by your business failed to send. A reason for the failure will be included in the callback.
        /// </summary>
        failed = 4,

        /// <summary>
        /// A message send by the user was deleted by the user. Upon receiving this notification, you should ensure that the message is deleted from your system if it was downloaded from the server.
        /// </summary>
        deleted = 5,

        /// <summary>
        /// A message your business sent contains an item in a catalog that is not available or does not exist.
        /// </summary>
        warning = 6
    }
}