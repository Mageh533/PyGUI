namespace PytubeGUI
{
    partial class PytubeGUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PytubeGUI));
            Download = new Button();
            UrlTextBox = new TextBox();
            FileExtensionCombo = new ComboBox();
            ResolutionCombo = new ComboBox();
            SuspendLayout();
            // 
            // Download
            // 
            Download.Anchor = AnchorStyles.Top;
            Download.BackColor = Color.DimGray;
            Download.ForeColor = Color.White;
            Download.Location = new Point(50, 213);
            Download.MaximumSize = new Size(150, 50);
            Download.MinimumSize = new Size(150, 50);
            Download.Name = "Download";
            Download.Size = new Size(150, 50);
            Download.TabIndex = 0;
            Download.Text = "Download";
            Download.UseVisualStyleBackColor = false;
            Download.Click += Download_Click;
            // 
            // UrlTextBox
            // 
            UrlTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            UrlTextBox.Location = new Point(50, 25);
            UrlTextBox.Name = "UrlTextBox";
            UrlTextBox.PlaceholderText = "YouTube URL";
            UrlTextBox.Size = new Size(508, 23);
            UrlTextBox.TabIndex = 1;
            UrlTextBox.TextChanged += UrlTextBox_TextChanged;
            // 
            // FileExtensionCombo
            // 
            FileExtensionCombo.FormattingEnabled = true;
            FileExtensionCombo.Items.AddRange(new object[] { ".mp4", ".mov", ".m4a", ".avi", "", ".mp3", ".wav", ".ogg", ".flac" });
            FileExtensionCombo.Location = new Point(481, 73);
            FileExtensionCombo.Name = "FileExtensionCombo";
            FileExtensionCombo.Size = new Size(77, 23);
            FileExtensionCombo.TabIndex = 3;
            FileExtensionCombo.Text = "Format";
            FileExtensionCombo.SelectedIndexChanged += FileExtensionCombo_SelectedIndexChanged;
            // 
            // ResolutionCombo
            // 
            ResolutionCombo.FormattingEnabled = true;
            ResolutionCombo.Location = new Point(50, 73);
            ResolutionCombo.Name = "ResolutionCombo";
            ResolutionCombo.Size = new Size(425, 23);
            ResolutionCombo.TabIndex = 4;
            ResolutionCombo.Text = "Resolution";
            ResolutionCombo.SelectedIndexChanged += ResolutionCombo_SelectedIndexChanged;
            // 
            // PytubeGUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(38, 38, 38);
            ClientSize = new Size(607, 275);
            Controls.Add(ResolutionCombo);
            Controls.Add(FileExtensionCombo);
            Controls.Add(UrlTextBox);
            Controls.Add(Download);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "PytubeGUI";
            Text = "PyGUI";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Download;
        private TextBox UrlTextBox;
        private ComboBox FileExtensionCombo;
        private ComboBox ResolutionCombo;
    }
}
