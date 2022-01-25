using System.Collections.Generic;
using WABA360Dialog.ApiClient.Payloads.Enums;
using WABA360Dialog.Common.Converters.Base;

namespace WABA360Dialog.ApiClient.Payloads.Converters
{
    internal class BlockingConverter : EnumConverter<Blocking>
    {
        protected override Blocking GetEnumValue(string value)
        {
            return EnumStringConverter.GetBlocking(value);
        }

        protected override string GetStringValue(Blocking value)
        {
            return value.GetString();
        }
    }

    public static partial class EnumStringConverter
    {
        private static readonly IReadOnlyDictionary<string, Blocking> BlockingStringToEnum =
            new Dictionary<string, Blocking>
            {
                { "no_wait", Blocking.no_wait },
                { "wait", Blocking.wait }
            };

        private static readonly IReadOnlyDictionary<Blocking, string> BlockingEnumToString =
            new Dictionary<Blocking, string>
            {
                { Blocking.no_wait, "no_wait" },
                { Blocking.wait, "wait" }
            };

        public static string GetString(this Blocking status)
        {
            return BlockingEnumToString.TryGetValue(status, out var stringValue)
                ? stringValue
                : "no_wait";
        }

        public static Blocking GetBlocking(string status)
        {
            return BlockingStringToEnum.TryGetValue(status, out var enumValue)
                ? enumValue
                : 0;
        }
    }
}