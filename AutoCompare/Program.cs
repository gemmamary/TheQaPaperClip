using System;
using System.IO;
using static AutoCompare.FailureLogs;
using static AutoCompare.FailureLogsComparison;

namespace AutoCompare
{
    public class Program
    {
        static void Main(string[] args)
        {                               
            // Gets the path to the Failure Logs folder
            var failureLogsFolderPath = GetFailureLogsFolderPath();
           
            // Gets the two latest logs in the directory based on when they were written to last.
            // If an older log is written to after new log(s) have been added, results may be inaccurate 
            string latestLog = GetLatestFailureLog(failureLogsFolderPath);
            string previousLog = GetSecondToLastFailureLog(failureLogsFolderPath);

            // Checks whether the two logs are the same or different
            AreTestFailuresDifferent(latestLog, previousLog);

            GetNewFailures(latestLog, previousLog);
            GetFixedFailures(latestLog, previousLog);

        }
    }
}
