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
    }
}
