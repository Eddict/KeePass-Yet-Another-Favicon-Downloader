namespace YetAnotherFaviconDownloader.UI
{
    partial class DownloadProvider
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtProviderURL = new System.Windows.Forms.TextBox();
            this.cboProviderList = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblSelectDownloadProvider = new System.Windows.Forms.Label();
            this.lblDownloadProviderURL = new System.Windows.Forms.Label();
            this.chkAccept = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtProviderURL
            // 
            this.txtProviderURL.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtProviderURL.Location = new System.Drawing.Point(20, 90);
            this.txtProviderURL.Margin = new System.Windows.Forms.Padding(4);
            this.txtProviderURL.Name = "txtProviderURL";
            this.txtProviderURL.ReadOnly = true;
            this.txtProviderURL.Size = new System.Drawing.Size(475, 22);
            this.txtProviderURL.TabIndex = 4;
            // 
            // cboProviderList
            // 
            this.cboProviderList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProviderList.FormattingEnabled = true;
            this.cboProviderList.Location = new System.Drawing.Point(20, 31);
            this.cboProviderList.Margin = new System.Windows.Forms.Padding(4);
            this.cboProviderList.Name = "cboProviderList";
            this.cboProviderList.Size = new System.Drawing.Size(475, 24);
            this.cboProviderList.TabIndex = 2;
            this.cboProviderList.SelectedIndexChanged += new System.EventHandler(this.cboProviderList_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(261, 180);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(113, 28);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(383, 180);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 28);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblSelectDownloadProvider
            // 
            this.lblSelectDownloadProvider.AutoSize = true;
            this.lblSelectDownloadProvider.Location = new System.Drawing.Point(16, 11);
            this.lblSelectDownloadProvider.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelectDownloadProvider.Name = "lblSelectDownloadProvider";
            this.lblSelectDownloadProvider.Size = new System.Drawing.Size(236, 16);
            this.lblSelectDownloadProvider.TabIndex = 1;
            this.lblSelectDownloadProvider.Text = "Please select your download provider:";
            // 
            // lblDownloadProviderURL
            // 
            this.lblDownloadProviderURL.AutoSize = true;
            this.lblDownloadProviderURL.Location = new System.Drawing.Point(16, 70);
            this.lblDownloadProviderURL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDownloadProviderURL.Name = "lblDownloadProviderURL";
            this.lblDownloadProviderURL.Size = new System.Drawing.Size(37, 16);
            this.lblDownloadProviderURL.TabIndex = 3;
            this.lblDownloadProviderURL.Text = "URL:";
            // 
            // chkAccept
            // 
            this.chkAccept.Checked = true;
            this.chkAccept.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAccept.Location = new System.Drawing.Point(20, 130);
            this.chkAccept.Margin = new System.Windows.Forms.Padding(4);
            this.chkAccept.Name = "chkAccept";
            this.chkAccept.Size = new System.Drawing.Size(476, 42);
            this.chkAccept.TabIndex = 7;
            this.chkAccept.Text = "I accept the Terms of Service and the Privacy Policy from the selected third-part" +
    "y download provider.";
            this.chkAccept.UseVisualStyleBackColor = false;
            this.chkAccept.CheckedChanged += new System.EventHandler(this.chkAccept_CheckedChanged);
            // 
            // DownloadProvider
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(512, 223);
            this.Controls.Add(this.chkAccept);
            this.Controls.Add(this.lblDownloadProviderURL);
            this.Controls.Add(this.lblSelectDownloadProvider);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cboProviderList);
            this.Controls.Add(this.txtProviderURL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DownloadProvider";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Download provider";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtProviderURL;
        private System.Windows.Forms.ComboBox cboProviderList;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblSelectDownloadProvider;
        private System.Windows.Forms.Label lblDownloadProviderURL;
        private System.Windows.Forms.CheckBox chkAccept;
    }
}