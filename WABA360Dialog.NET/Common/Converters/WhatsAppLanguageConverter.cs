using System.Collections.Generic;
using WABA360Dialog.Common.Converters.Base;
using WABA360Dialog.Common.Enums;

namespace WABA360Dialog.Common.Converters
{
    internal class WhatsAppLanguageConverter : EnumConverter<WhatsAppLanguage>
    {
        protected override WhatsAppLanguage GetEnumValue(string value) => EnumStringConverter.GetTemplateLanguage(value);

        protected override string GetStringValue(WhatsAppLanguage value) => value.GetString();
    }
    
    public static partial class EnumStringConverter
    {
        private static readonly IReadOnlyDictionary<string, WhatsAppLanguage> TemplateLanguageStringToEnum =
            new Dictionary<string, WhatsAppLanguage>
            {
                { "af", WhatsAppLanguage.Afrikaans },
                { "sq", WhatsAppLanguage.Albanian },
                { "ar", WhatsAppLanguage.Arabic },
                { "az", WhatsAppLanguage.Azerbaijani },
                { "bn", WhatsAppLanguage.Bengali },
                { "bg", WhatsAppLanguage.Bulgarian },
                { "ca", WhatsAppLanguage.Catalan },
                { "zh_CN", WhatsAppLanguage.Chinese_CN },
                { "zh_HK", WhatsAppLanguage.Chinese_HK },
                { "zh_TW", WhatsAppLanguage.Chinese_TW },
                { "hr", WhatsAppLanguage.Croatian },
                { "cs", WhatsAppLanguage.Czech },
                { "da", WhatsAppLanguage.Danish },
                { "nl", WhatsAppLanguage.Dutch },
                { "en", WhatsAppLanguage.English },
                { "en_GB", WhatsAppLanguage.English_UK },
                { "en_US", WhatsAppLanguage.English_US },
                { "et", WhatsAppLanguage.Estonian },
                { "fil", WhatsAppLanguage.Filipino },
                { "fi", WhatsAppLanguage.Finnish },
                { "fr", WhatsAppLanguage.French },
                { "ka", WhatsAppLanguage.Georgian },
                { "de", WhatsAppLanguage.German },
                { "el", WhatsAppLanguage.Greek },
                { "gu", WhatsAppLanguage.Gujarati },
                { "ha", WhatsAppLanguage.Hausa },
                { "he", WhatsAppLanguage.Hebrew },
                { "hi", WhatsAppLanguage.Hindi },
                { "hu", WhatsAppLanguage.Hungarian },
                { "id", WhatsAppLanguage.Indonesian },
                { "ga", WhatsAppLanguage.Irish },
                { "it", WhatsAppLanguage.Italian },
                { "ja", WhatsAppLanguage.Japanese },
                { "kn", WhatsAppLanguage.Kannada },
                { "kk", WhatsAppLanguage.Kazakh },
                { "rw_RW", WhatsAppLanguage.Kinyarwanda },
                { "ko", WhatsAppLanguage.Korean },
                { "ky_KG", WhatsAppLanguage.Kyrgyz },
                { "lo", WhatsAppLanguage.Lao },
                { "lv", WhatsAppLanguage.Latvian },
                { "lt", WhatsAppLanguage.Lithuanian },
                { "mk", WhatsAppLanguage.Macedonian },
                { "ms", WhatsAppLanguage.Malay },
                { "ml", WhatsAppLanguage.Malayalam },
                { "mr", WhatsAppLanguage.Marathi },
                { "nb", WhatsAppLanguage.Norwegian },
                { "fa", WhatsAppLanguage.Persian },
                { "pl", WhatsAppLanguage.Polish },
                { "pt_BR", WhatsAppLanguage.Portuguese_BR },
                { "pt_PT", WhatsAppLanguage.Portuguese_POR },
                { "pa", WhatsAppLanguage.Punjabi },
                { "ro", WhatsAppLanguage.Romanian },
                { "ru", WhatsAppLanguage.Russian },
                { "sr", WhatsAppLanguage.Serbian },
                { "sk", WhatsAppLanguage.Slovak },
                { "sl", WhatsAppLanguage.Slovenian },
                { "es", WhatsAppLanguage.Spanish },
                { "es_AR", WhatsAppLanguage.Spanish_ARG },
                { "es_ES", WhatsAppLanguage.Spanish_SPA },
                { "es_MX", WhatsAppLanguage.Spanish_MEX },
                { "sw", WhatsAppLanguage.Swahili },
                { "sv", WhatsAppLanguage.Swedish },
                { "ta", WhatsAppLanguage.Tamil },
                { "te", WhatsAppLanguage.Telugu },
                { "th", WhatsAppLanguage.Thai },
                { "tr", WhatsAppLanguage.Turkish },
                { "uk", WhatsAppLanguage.Ukrainian },
                { "ur", WhatsAppLanguage.Urdu },
                { "uz", WhatsAppLanguage.Uzbek },
                { "vi", WhatsAppLanguage.Vietnamese },
                { "zu", WhatsAppLanguage.Zulu },
            };

        private static readonly IReadOnlyDictionary<WhatsAppLanguage, string> TemplateLanguageEnumToString =
            new Dictionary<WhatsAppLanguage, string>
            {
                { WhatsAppLanguage.Afrikaans, "af" },
                { WhatsAppLanguage.Albanian, "sq" },
                { WhatsAppLanguage.Arabic, "ar" },
                { WhatsAppLanguage.Azerbaijani, "az" },
                { WhatsAppLanguage.Bengali, "bn" },
                { WhatsAppLanguage.Bulgarian, "bg" },
                { WhatsAppLanguage.Catalan, "ca" },
                { WhatsAppLanguage.Chinese_CN, "zh_CN" },
                { WhatsAppLanguage.Chinese_HK, "zh_HK" },
                { WhatsAppLanguage.Chinese_TW, "zh_TW" },
                { WhatsAppLanguage.Croatian, "hr" },
                { WhatsAppLanguage.Czech, "cs" },
                { WhatsAppLanguage.Danish, "da" },
                { WhatsAppLanguage.Dutch, "nl" },
                { WhatsAppLanguage.English, "en" },
                { WhatsAppLanguage.English_UK, "en_GB" },
                { WhatsAppLanguage.English_US, "en_US" },
                { WhatsAppLanguage.Estonian, "et" },
                { WhatsAppLanguage.Filipino, "fil" },
                { WhatsAppLanguage.Finnish, "fi" },
                { WhatsAppLanguage.French, "fr" },
                { WhatsAppLanguage.Georgian, "ka" },
                { WhatsAppLanguage.German, "de" },
                { WhatsAppLanguage.Greek, "el" },
                { WhatsAppLanguage.Gujarati, "gu" },
                { WhatsAppLanguage.Hausa, "ha" },
                { WhatsAppLanguage.Hebrew, "he" },
                { WhatsAppLanguage.Hindi, "hi" },
                { WhatsAppLanguage.Hungarian, "hu" },
                { WhatsAppLanguage.Indonesian, "id" },
                { WhatsAppLanguage.Irish, "ga" },
                { WhatsAppLanguage.Italian, "it" },
                { WhatsAppLanguage.Japanese, "ja" },
                { WhatsAppLanguage.Kannada, "kn" },
                { WhatsAppLanguage.Kazakh, "kk" },
                { WhatsAppLanguage.Kinyarwanda, "rw_RW" },
                { WhatsAppLanguage.Korean, "ko" },
                { WhatsAppLanguage.Kyrgyz, "ky_KG" },
                { WhatsAppLanguage.Lao, "lo" },
                { WhatsAppLanguage.Latvian, "lv" },
                { WhatsAppLanguage.Lithuanian, "lt" },
                { WhatsAppLanguage.Macedonian, "mk" },
                { WhatsAppLanguage.Malay, "ms" },
                { WhatsAppLanguage.Malayalam, "ml" },
                { WhatsAppLanguage.Marathi, "mr" },
                { WhatsAppLanguage.Norwegian, "nb" },
                { WhatsAppLanguage.Persian, "fa" },
                { WhatsAppLanguage.Polish, "pl" },
                { WhatsAppLanguage.Portuguese_BR, "pt_BR" },
                { WhatsAppLanguage.Portuguese_POR, "pt_PT" },
                { WhatsAppLanguage.Punjabi, "pa" },
                { WhatsAppLanguage.Romanian, "ro" },
                { WhatsAppLanguage.Russian, "ru" },
                { WhatsAppLanguage.Serbian, "sr" },
                { WhatsAppLanguage.Slovak, "sk" },
                { WhatsAppLanguage.Slovenian, "sl" },
                { WhatsAppLanguage.Spanish, "es" },
                { WhatsAppLanguage.Spanish_ARG, "es_AR" },
                { WhatsAppLanguage.Spanish_SPA, "es_ES" },
                { WhatsAppLanguage.Spanish_MEX, "es_MX" },
                { WhatsAppLanguage.Swahili, "sw" },
                { WhatsAppLanguage.Swedish, "sv" },
                { WhatsAppLanguage.Tamil, "ta" },
                { WhatsAppLanguage.Telugu, "te" },
                { WhatsAppLanguage.Thai, "th" },
                { WhatsAppLanguage.Turkish, "tr" },
                { WhatsAppLanguage.Ukrainian, "uk" },
                { WhatsAppLanguage.Urdu, "ur" },
                { WhatsAppLanguage.Uzbek, "uz" },
                { WhatsAppLanguage.Vietnamese, "vi" },
                { WhatsAppLanguage.Zulu, "zu" },
            };
        
        public static string GetString(this WhatsAppLanguage language) =>
            TemplateLanguageEnumToString.TryGetValue(language, out var stringValue)
                ? stringValue
                : "unknown";

        public static WhatsAppLanguage GetTemplateLanguage(string language) =>
            TemplateLanguageStringToEnum.TryGetValue(language, out var enumValue)
                ? enumValue
                : 0;
    }
}