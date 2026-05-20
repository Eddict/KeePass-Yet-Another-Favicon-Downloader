using KeePass.Plugins;
using KeePass.Resources;
using KeePassLib.Interfaces;
using KeePassLib.Utility;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace YetAnotherFaviconDownloader.UI
{
    public partial class DownloadProvider : Form
    {
        // Plugin host interface
        private IPluginHost pluginHost;

        public DownloadProvider(IPluginHost host)
        {
            InitializeComponent();

            // Translate some stuff
            btnSave.Text = KPRes.Save;
            btnCancel.Text = KPRes.Cancel;

            // KeePass plugin host
            pluginHost = host;

            // Providers
            cboProviderList.Items.Clear();
            cboProviderList.Items.AddRange(ProviderList.GetDefaultList());
            cboProviderList.EnableItemToolTips(item => ((Provider)item).URL);

            // Lookup provider on list
            var url = YetAnotherFaviconDownloaderExt.Config.GetDownloadProvider();
            var provider = ProviderList.FindByURL(url);
            if (provider == null)
            {
                if (string.IsNullOrEmpty(url))
                {
                    // Local (default)
                    cboProviderList.SelectedIndex = 0;
                    return;
                }

                // Checks if URL provided is valid
                if (!ProviderList.IsValidURL(url))
                {
                    cboProviderList.SelectedIndex = 0;    // invalid
                    return;
                }

                // Provider
                ProviderList.SetProviderURL(url);
                cboProviderList.SelectedIndex = cboProviderList.Items.Count - 1;
                return;
            }

            // Select corresponding item
            cboProviderList.SelectedIndex = cboProviderList.FindStringExact(provider.Name);
        }

        private void cboProviderList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var obj = sender as ComboBox;

            // Local (default)
            if (obj.SelectedIndex <= 0)
            {
                txtProviderURL.ReadOnly = true;
                txtProviderURL.Text = "";
                chkAccept.Enabled = false;
                btnSave.Enabled = true;
            }
            // Third party providers
            else
            {
                var provider = obj.SelectedItem as Provider;

                txtProviderURL.ReadOnly = provider.Name != ProviderList.URLName;
                txtProviderURL.Text = provider.URL;
                chkAccept.Enabled = true;
                btnSave.Enabled = false;
            }
            chkAccept.Checked = false;

            ToolTip comboToolTip = new ToolTip();
            comboToolTip.SetToolTip(obj, txtProviderURL.Text);
        }
        private void chkAccept_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = !chkAccept.Enabled || chkAccept.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var provider = cboProviderList.SelectedItem as Provider;
            if (provider.Name == ProviderList.URLName)
            {
                var url = txtProviderURL.Text;

                if (!ProviderList.IsValidURL(url))
                {
                    MessageService.ShowWarning(url, KPRes.InvalidUrl);
                    return;
                }
                ProviderList.SetProviderURL(url);
            }

            YetAnotherFaviconDownloaderExt.Config.SetDownloadProvider(provider.URL);

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
