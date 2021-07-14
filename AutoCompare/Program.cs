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
            // Change these variables to the dates in the file names you want to compare
            var previous = "07072021";
            var latest = "08072021";
                               
            // Gets the path to the Failure Logs folder
            var failureLogsFolderPath = GetFailureLogsFolderPath();
           
            // Gets the two logs to compare
            string latestLog = GetFailureLogFromDate(failureLogsFolderPath, latest);
            string previousLog = GetFailureLogFromDate(failureLogsFolderPath, previous);

            // Checks whether the two logs are the same or different
            AreTestFailuresDifferent(latestLog, previousLog);

            GetNewFailures(latestLog, previousLog);
            GetFixedFailures(latestLog, previousLog);

        }
    }
}
