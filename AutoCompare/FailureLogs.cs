using System.IO;
using System.Linq;

namespace AutoCompare
{
    public static class FailureLogs
    {
        public static string GetFailureLogFromDate(string root, string date) => 
            Directory.EnumerateFiles(root).First(log => log.Contains(date));

        public static string GetFailureLogsFolderPath()
        {
            var dir = Directory.GetCurrentDirectory();
            var projectPath = @"TheQaPaperClip\AutoCompare";
            var logsPath = @"TheQaPaperClip\AutoCompare\files\FailureLogs";
            var i = dir.IndexOf(projectPath);
            
            return $"{dir.Substring(0, i)}{logsPath}";


        }
    }
}
