using System.Diagnostics;

namespace PytubeGUI
{
    public partial class PytubeGUI : Form
    {
        private string url = "";
        private string fileExtension = "";
        private string savePath = "./";

        public PytubeGUI()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Download_Click(object sender, EventArgs e)
        {
            // Open a folder browser dialog to select the download location
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                savePath = folderBrowserDialog.SelectedPath;
                Download_Video();
            }
        }

        private void UrlTextBox_TextChanged(object sender, EventArgs e)
        {
            url = UrlTextBox.Text;
        }

        private void Download_Video()
        {
            try
            {
                // Download the video using the downloader.py script
                var process = new Process()
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "downloader.exe",
                        Arguments = $"{url} {savePath}",
                        RedirectStandardOutput = false,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                };
                process.Start();
                process.WaitForExit();
                MessageBox.Show("Video downloaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FileExtensionCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            fileExtension = FileExtensionCombo.SelectedItem as string ?? ".mp4"; // Could be null, default to .mp4
        }
    }
}
