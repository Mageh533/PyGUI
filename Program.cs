using System.Diagnostics;

namespace PytubeGUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            if (!IsPythonInstalled())
            {
                MessageBox.Show("Python is not installed on your system. Please install Python and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Application.Run(new PytubeGUI());
        }

        // Check if Python is installed on the system
        private static bool IsPythonInstalled()
        {
            try
            {
                var process = new Process()
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "python",
                        Arguments = "--version",
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                };
                process.Start();
                process.WaitForExit();
                return process.ExitCode == 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}