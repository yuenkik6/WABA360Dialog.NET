using System.Collections.Generic;
using WABA360Dialog.Common.Converters.Base;

namespace WABA360Dialog.PartnerClient.Payloads.Enums
{
    internal class ClientStatusConverter : EnumConverter<ClientStatus>
    {
        protected override ClientStatus GetEnumValue(string value) =>
            EnumStringConverter.GetClientStatus(value);

        protected override string GetStringValue(ClientStatus value) => value.GetString();
    }

    public static partial class EnumStringConverter
    {
        private static readonly IReadOnlyDictionary<string, ClientStatus> ClientStatusStringToEnum =
            new Dictionary<string, ClientStatus>
            {
                { "unknown", ClientStatus.unknown },
                { "active", ClientStatus.active },
            };

        private static readonly IReadOnlyDictionary<ClientStatus, string> ClientStatusEnumToString =
            new Dictionary<ClientStatus, string>
            {
                { ClientStatus.unknown, "unknown" },
                { ClientStatus.active, "active" },
            };

        public static string GetString(this ClientStatus status) =>
            ClientStatusEnumToString.TryGetValue(status, out var stringValue)
                ? stringValue
                : "unknown";

        public static ClientStatus GetClientStatus(string status) =>
            ClientStatusStringToEnum.TryGetValue(status, out var enumValue)
                ? enumValue
                : 0;
    }
}