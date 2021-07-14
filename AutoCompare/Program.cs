using System;
using System.IO;
using static AutoCompare.FailureLogs;
using static AutoCompare.FailureLogsComparison;
using static AutoCompare.FailedTests;

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

            Console.WriteLine($"Total Failures in previous run: {GetFailedTestCaseCount(previousLog)}");
            Console.WriteLine($"Total failures in latest run: {GetFailedTestCaseCount(latestLog)}");

            // Checks whether the two logs are the same or different
            AreTestFailuresDifferent(latestLog, previousLog);

            // Outputs new failures since the last run
            GetNewFailures(latestLog, previousLog);

            // Outputs failures from the previous run that are no longer failing
            GetFixedFailures(latestLog, previousLog);

        }
    }
}
