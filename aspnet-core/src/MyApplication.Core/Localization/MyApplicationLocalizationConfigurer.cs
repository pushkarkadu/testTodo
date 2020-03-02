using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace MyApplication.Localization
{
    public static class MyApplicationLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(MyApplicationConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(MyApplicationLocalizationConfigurer).GetAssembly(),
                        "MyApplication.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
