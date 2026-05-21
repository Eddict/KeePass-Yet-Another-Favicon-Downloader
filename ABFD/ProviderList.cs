using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ABetterFaviconDownloader
{
    static class ProviderList
    {
        public static readonly string URLName = "URL";

        private static readonly List<Provider> providers = new List<Provider>();
        private static readonly Provider provider = new Provider(URLName, null);

        // Top Favicon APIs for High-Load Use Cases in 2025
        // https://ithy.com/article/top-favicon-apis-hwb5am2x
        static ProviderList()
        {
            providers.Add(new Provider("None (Default)", null));
            providers.Add(new Provider("DuckDuckGo", "https://icons.duckduckgo.com/ip3/{URL:HOST}.ico"));
            providers.Add(new Provider("Favicone", "https://favicone.com/{URL:HOST}?s={YAFD:ICON_SIZE}"));
            providers.Add(new Provider("Google", "https://www.google.com/s2/favicons?domain={URL:HOST}&sz={YAFD:ICON_SIZE}"));
            providers.Add(new Provider("Grabicon", "https://grabicon.p.rapidapi.com/icon?domain={URL:HOST}&size={YAFD:ICON_SIZE}"));
            providers.Add(new Provider("Icon Horse", "https://icon.horse/icon/{URL:HOST}"));
            providers.Add(new Provider("Yandex", "https://favicon.yandex.net/favicon/{URL:HOST}"));
            providers.Add(provider);
        }

        public static Provider[] GetDefaultList()
        {
            return providers.ToArray();
        }

        public static Provider FindByURL(string url)
        {
            return providers.Find(x => x.URL == url);
        }

        public static void SetProviderURL(string url)
        {
            provider.URL = url;
        }

        public static bool IsValidURL(string url)
        {
            // HTTP URI schema
            var httpSchema = new Regex(@"^http(s)?://.+", RegexOptions.IgnoreCase | RegexOptions.Compiled);

            if (!httpSchema.IsMatch(url))
            {
                return false;
            }

            Uri result;
            return Uri.TryCreate(url, UriKind.Absolute, out result);
        }

        // Add a method to get provider name by URL
        public static string GetProviderNameByUrl(string url)
        {
            if (string.IsNullOrEmpty(url)) return "Unknown";
            foreach (var provider in providers)
            {
                if (string.Equals(provider.URL, url, StringComparison.OrdinalIgnoreCase))
                    return provider.Name;
            }
            return url; // fallback to url if not found
        }
    }
}
