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
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                };
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

        // Methods that use the ffmpeg
        public static void Join_Audio_Video_Stream(string audioPath, string videoPath, string savePath)
        {
            try
            {
                var process = new Process()
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "Tools/ffmpeg.exe",
                        Arguments = $"-i {audioPath} -i {videoPath} -c:v copy -c:a aac {savePath}",
                        RedirectStandardOutput = false,
                        UseShellExecute = false,
                        CreateNoWindow = false
                    }
                };
                process.Start();
                process.WaitForExit();
                MessageBox.Show("Audio and video streams joined successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Convert_Video(string videoPath, string savePath)
        {
            try
            {
                var process = new Process()
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "Tools/ffmpeg.exe",
                        Arguments = $"-i {videoPath} {savePath}",
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                };
                process.Start();
                process.WaitForExit();

                MessageBox.Show("Video converted successfully!" + process.StandardOutput.ReadToEnd(), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
