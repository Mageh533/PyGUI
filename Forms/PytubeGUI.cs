using System.Diagnostics;
using System.Text.RegularExpressions;
using PyGUI.Scripts;

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
                ScriptMethods.Download_Video(url, resolution, savePath);
                // Check if we need to join the audio and video streams
                if(File.Exists(savePath + "/AUDIO-" + video_details.GetValueOrDefault("title") + ".mp4"))
                {
                    ScriptMethods.Join_Audio_Video_Stream(savePath + "/AUDIO-" + video_details.GetValueOrDefault("title") + ".mp4",
                        savePath + "/" + video_details.GetValueOrDefault("title") + ".mp4",
                        savePath + "/Joined-" + video_details.GetValueOrDefault("title") + ".mp4");
                }
                // Then convert the video to the format selected
                if(fileExtension != ".mp4")
                {
                    ScriptMethods.Convert_Video(savePath + "/Joined-" + video_details.GetValueOrDefault("title") + ".mp4",
                        savePath + "/Converted-" + video_details.GetValueOrDefault("title") + fileExtension);
                }
            }
        }

        private void UrlTextBox_TextChanged(object sender, EventArgs e)
        {
            url = UrlTextBox.Text;
            ScriptMethods.Get_Video_Details(url, video_details);
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
    }
}
