using KeePass.App.Configuration;

namespace YetAnotherFaviconDownloader
{
    public sealed class Configuration
    {
        private readonly AceCustomConfig config;

        /// <summary>
        /// Plugin name used on settings to avoid collisions
        /// </summary>
        private const string pluginName = "YetAnotherFaviconDownloader.";

        /// <summary>
        /// Automatic prefix URLs with http(s):// setting (https first, then http)
        /// </summary>
        private const string automaticPrefixURLs = pluginName + "PrefixURLs";
        private bool? m_automaticPrefixURLs = null;

        /// <summary>
        /// Use title field if URL field is empty setting
        /// </summary>
        private const string useTitleField = pluginName + "TitleField";
        private bool? m_useTitleField = null;

        /// <summary>
        /// Update last modified date when adding/updating icons
        /// </summary>
        private const string updateLastModified = pluginName + "UpdateLastModified";
        private bool? m_updateLastModified = null;

        /// <summary>
        /// Maximum icon size
        /// </summary>
        private const string maximumIconSize = pluginName + "MaximumIconSize";
        private int? m_maximumIconSize = null;

        /// <summary>
        /// Download provider
        /// </summary>
        private const string downloadProvider = pluginName + "DownloadProvider";
        private string m_downloadProvider = null;

        /// <summary>
        /// RapidAPI key
        /// </summary>
        private const string apiKey = pluginName + "RapidAPIKey";
        private string m_apiKey = null;

        public Configuration(AceCustomConfig aceCustomConfig)
        {
            config = aceCustomConfig;
        }

        public bool GetAutomaticPrefixURLs()
        {
            if (!m_automaticPrefixURLs.HasValue)
            {
                m_automaticPrefixURLs = config.GetBool(automaticPrefixURLs, false);
            }

            return m_automaticPrefixURLs.Value;
        }

        public void SetAutomaticPrefixURLs(bool value)
        {
            m_automaticPrefixURLs = value;
            config.SetBool(automaticPrefixURLs, value);
        }

        public bool GetUseTitleField()
        {
            if (!m_useTitleField.HasValue)
            {
                m_useTitleField = config.GetBool(useTitleField, false);
            }

            return m_useTitleField.Value;
        }

        public void SetUseTitleField(bool value)
        {
            m_useTitleField = value;
            config.SetBool(useTitleField, value);
        }

        public bool GetUpdateLastModified()
        {
            if (!m_updateLastModified.HasValue)
            {
                m_updateLastModified = config.GetBool(updateLastModified, true);
            }

            return m_updateLastModified.Value;
        }

        public void SetUpdateLastModified(bool value)
        {
            m_updateLastModified = value;
            config.SetBool(updateLastModified, value);
        }

        public int GetMaximumIconSize()
        {
            if (!m_maximumIconSize.HasValue)
            {
                // int is enough
                m_maximumIconSize = (int)config.GetLong(maximumIconSize, 128);
            }

            return m_maximumIconSize.Value;
        }

        public void SetMaximumIconSize(int value)
        {
            m_maximumIconSize = value;
            config.SetLong(maximumIconSize, value);
        }

        public string GetDownloadProvider()
        {
            if (string.IsNullOrEmpty(m_downloadProvider))
            {
                m_downloadProvider = config.GetString(downloadProvider, "");
            }

            return m_downloadProvider;
        }

        public void SetDownloadProvider(string value)
        {
            m_downloadProvider = value;
            config.SetString(downloadProvider, value);
        }

        public string GetRapidAPIKey()
        {
            if (string.IsNullOrEmpty(m_apiKey))
            {
                m_apiKey = config.GetString(apiKey, "");
            }

            return m_apiKey;
        }

        public void SetRapidAPIKey(string value)
        {
            m_apiKey = value;
            config.SetString(apiKey, value);
        }
    }
}
