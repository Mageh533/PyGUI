using System.Diagnostics;

namespace PyGUI.Scripts
{
    internal class ScriptMethods
    {
        // Methods that use the downloader py
        public static void Download_Video(string url, string resolution, string savePath)
        {
            try
            {
                var process = new Process()
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "Tools/downloader.exe",
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

        public static void Get_Video_Details(string url, Dictionary<string, string> video_details)
        {
            try
            {
                var process = new Process()
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "Tools/downloader.exe",
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
