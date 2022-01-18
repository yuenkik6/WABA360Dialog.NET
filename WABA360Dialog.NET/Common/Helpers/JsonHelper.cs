using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WABA360Dialog.Common.Helpers
{
    internal static class JsonHelper
    {
        private static readonly JsonSerializerSettings JsonSerializerSettings = new()
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy
                {
                    OverrideSpecifiedNames = false
                }
            },
            DateTimeZoneHandling = DateTimeZoneHandling.Utc
        };

        public static string SerializeObjectToJson(object obj)
        {
            return obj == null ? null : JsonConvert.SerializeObject(obj, JsonSerializerSettings);

        }

        public static string SerializeObjectToJson<T>(T obj) where T : new()
        {
            return obj == null ? null : JsonConvert.SerializeObject(obj, JsonSerializerSettings);

        }
    }
}