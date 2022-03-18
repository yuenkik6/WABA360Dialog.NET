using System.Collections.Generic;
using WABA360Dialog.Common.Converters.Base;
using WABA360Dialog.PartnerClient.Payloads.Enums;

namespace WABA360Dialog.PartnerClient.Converters
{
    internal class FacebookAccountStatusConverter : EnumConverter<FacebookAccountStatus>
    {
        protected override FacebookAccountStatus GetEnumValue(string value) =>
            EnumStringConverter.GetFacebookAccountStatus(value);

        protected override string GetStringValue(FacebookAccountStatus value) =>
            value.GetString();
    }

    public static partial class EnumStringConverter
    {
        private static readonly IReadOnlyDictionary<string, FacebookAccountStatus> FacebookAccountStatusStringToEnum =
            new Dictionary<string, FacebookAccountStatus>
            {
                { "unknown", FacebookAccountStatus.unknown },
                { "verified", FacebookAccountStatus.verified },
                { "not_verified", FacebookAccountStatus.not_verified },
                { "rejected", FacebookAccountStatus.rejected },
                { "pending_submission", FacebookAccountStatus.pending_submission },
                { "failed", FacebookAccountStatus.failed },
                { "pending", FacebookAccountStatus.pending },
                { "pending_need_more_info", FacebookAccountStatus.pending_need_more_info },
            };

        private static readonly IReadOnlyDictionary<FacebookAccountStatus, string> FacebookAccountStatusEnumToString =
            new Dictionary<FacebookAccountStatus, string>
            {
                { FacebookAccountStatus.unknown, "unknown" },
                { FacebookAccountStatus.verified, "verified" },
                { FacebookAccountStatus.not_verified, "not_verified" },
                { FacebookAccountStatus.rejected, "rejected" },
                { FacebookAccountStatus.pending_submission, "pending_submission" },
                { FacebookAccountStatus.failed, "failed" },
                { FacebookAccountStatus.pending, "pending" },
                { FacebookAccountStatus.pending_need_more_info, "pending_need_more_info" },
            };

        public static string GetString(this FacebookAccountStatus status) =>
            FacebookAccountStatusEnumToString.TryGetValue(status, out var stringValue)
                ? stringValue
                : "unknown";

        public static FacebookAccountStatus GetFacebookAccountStatus(string status) =>
            FacebookAccountStatusStringToEnum.TryGetValue(status, out var enumValue)
                ? enumValue
                : 0;
    }
}