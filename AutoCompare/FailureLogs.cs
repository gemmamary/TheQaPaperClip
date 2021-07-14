using System;
using System.IO;
using System.Linq;

namespace AutoCompare
{
    public static class FailureLogs
    {
        /// <summary>
        /// Gets the failure log from a certain date
        /// </summary>
        /// <param name="root">The file path to the folder containing the logs</param>
        /// <param name="date">The date added to the failure log name</param>
        /// <returns>The full file path to the failure log</returns>
        public static string GetFailureLogFromDate(string root, string date) => 
            Directory.EnumerateFiles(root).First(log => log.Contains(date));

        /// <summary>
        /// Gets the path for the Failure Logs folder 
        /// </summary>
        /// <returns>The file path to the folder containing the failure logs</returns>
        public static string GetFailureLogsFolderPath()
        {
            // Gets the file path of the directory the program is running from
            var dir = Directory.GetCurrentDirectory();

            // Amends the directory file path to be the file path to the failure logs folder
            var projectPath = @"TheQaPaperClip\AutoCompare";
            var logsPath = @"TheQaPaperClip\AutoCompare\files\FailureLogs";
            var i = dir.IndexOf(projectPath);
            
            return $"{dir.Substring(0, i)}{logsPath}";

        }

        /// <summary>
        /// Get the latest file in the specified directory
        /// </summary>
        /// <param name="root">The directory to get the latest file from</param>
        /// <returns>The full file path of the latest file in the directory</returns>
        public static string GetLatestFailureLog(string root)
        {
            var latest = new DirectoryInfo(root).GetFiles().OrderByDescending(x => x.LastWriteTimeUtc).First();

            return latest.FullName;
        }

        /// <summary>
        /// Gets the second to last file in the specified directory
        /// </summary>
        /// <param name="root">The directory to get the second to last file from</param>
        /// <returns>The full file path of the second to last file in the directory</returns>
        public static string GetSecondToLastFailureLog(string root)
        {
            var previous = new DirectoryInfo(root).GetFiles().OrderByDescending(x => x.LastWriteTimeUtc).ElementAt(1);

            return previous.FullName;
        }
    }
}
