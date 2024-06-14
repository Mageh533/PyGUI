using System.Diagnostics;

namespace PytubeGUI
{
    public partial class PytubeGUI : Form
    {
        private string url = "";

        public PytubeGUI()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Download the video using the downloader.py script
                var process = new Process()
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "downloader.exe",
                        Arguments = $"{url} ./",
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                };
                process.Start();
                process.WaitForExit();
                MessageBox.Show("Video downloaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            url = UrlTextBox.Text;
        }
    }
}
