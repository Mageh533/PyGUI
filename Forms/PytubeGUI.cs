using System.Diagnostics;
using System.Text.RegularExpressions;

namespace PytubeGUI
{
    public partial class PytubeGUI : Form
    {
        private string url = "";
        private string fileExtension = "";
        private string resolution = "";
        private string savePath = "./";

        private Dictionary<string, string> video_details = new Dictionary<string, string>();

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
            Get_Video_Details();
            ResolutionCombo.Items.Clear();
            if (video_details.ContainsKey("resolutions"))
            {
                string formatted = Regex.Replace(video_details.GetValueOrDefault("resolutions"), "\\[|\\]|'| ", ""); // Would you believe me if I told you that this is the first time I learned regex
                ResolutionCombo.Items.AddRange(formatted.Split(","));
            }
        }

        private void FileExtensionCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            fileExtension = FileExtensionCombo.SelectedItem as string ?? ".mp4";
        }

        private void ResolutionCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            resolution = ResolutionCombo.SelectedItem as string ?? "";
        }

        // Methods that use the downloader py
        private void Download_Video()
        {
            try
            {
                var process = new Process()
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "downloader.exe",
                        Arguments = $"0 {url} {resolution} {savePath}", // Mode 0 downloads the video
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

        private void Get_Video_Details()
        {
            try
            {
                var process = new Process()
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "downloader.exe",
                        Arguments = $"1 {url}", // Mode 1 gets the video details
                        RedirectStandardOutput = false,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                };
                process.StartInfo.RedirectStandardOutput = true;
                process.Start();
                process.WaitForExit();
                var outputString = process.StandardOutput.ReadToEnd();

                video_details.Clear();

                // Split the output and turn it into a dictionary
                string[] eachLine = outputString.Split(";");
                foreach (string line in eachLine)
                {
                    string[] keyValue = line.Split("=");
                    video_details.Add(keyValue[0], keyValue[1]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
