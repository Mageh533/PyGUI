﻿namespace PytubeGUI
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
            label1 = new Label();
            SuspendLayout();
            // 
            // Download
            // 
            Download.Anchor = AnchorStyles.Top;
            Download.Location = new Point(93, 156);
            Download.MaximumSize = new Size(150, 50);
            Download.MinimumSize = new Size(150, 50);
            Download.Name = "Download";
            Download.Size = new Size(150, 50);
            Download.TabIndex = 0;
            Download.Text = "Download";
            Download.UseVisualStyleBackColor = true;
            Download.Click += Download_Click;
            // 
            // UrlTextBox
            // 
            UrlTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            UrlTextBox.Location = new Point(47, 104);
            UrlTextBox.Name = "UrlTextBox";
            UrlTextBox.Size = new Size(259, 23);
            UrlTextBox.TabIndex = 1;
            UrlTextBox.TextChanged += UrlTextBox_TextChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label1.AutoSize = true;
            label1.Location = new Point(47, 86);
            label1.Name = "label1";
            label1.Size = new Size(78, 15);
            label1.TabIndex = 2;
            label1.Text = "Youtube URL:";
            // 
            // PytubeGUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(352, 304);
            Controls.Add(label1);
            Controls.Add(UrlTextBox);
            Controls.Add(Download);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(368, 343);
            MinimumSize = new Size(368, 343);
            Name = "PytubeGUI";
            Text = "PytubeGUI";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Download;
        private TextBox UrlTextBox;
        private Label label1;
    }
}
