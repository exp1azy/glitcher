using System.Diagnostics;

namespace Glitcher
{
    /// <summary>
    /// Provides functionality to start processes in the operating system.
    /// </summary>
    internal class ProcessRunner
    {
        /// <summary>
        /// Starts a process using the specified file or application.
        /// </summary>
        /// <param name="fileName">The name or path of the file to be executed.</param>
        public static void Start(string fileName)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = fileName,
                UseShellExecute = true
            });
        }
    }
}
