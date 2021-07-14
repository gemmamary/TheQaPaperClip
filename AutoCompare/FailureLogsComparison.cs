using System;
using System.Collections.Generic;
using System.Linq;
using static AutoCompare.FailedTests;
using static AutoCompare.LogResults;

namespace AutoCompare
{
    public static class FailureLogsComparison
    {
        /// <summary>
        /// Checks for differences between two logs and writes the result to the console
        /// </summary>
        /// <param name="latestFailureLog">The latest failure log</param>
        /// <param name="previousFailureLog">The previous failure log</param>
        /// <returns>True if the logs are the same, false if logs are different</returns>
        public static bool AreTestFailuresDifferent(string latestFailureLog, string previousFailureLog)
        {
            var latestFailures = GetFailedTestCaseIds(latestFailureLog);
            var previousFailures = GetFailedTestCaseIds(previousFailureLog);

            // Compare latest failures in a log against previous failures in a log
            var areFailuresTheSame = latestFailures.SequenceEqual(previousFailures);

            OutputResultsToConsole(areFailuresTheSame, "The latest logs contain the same failures as the previous log.", 
                "The latest logs contain different failures than the previous log.");

            return areFailuresTheSame;
        }

        /// <summary>
        /// Gets test case IDs of failures that are in the latest failure log but not the previous failure log. 
        /// Writes the results to the console
        /// </summary>
        /// <param name="latestFailureLog">The latest failure log</param>
        /// <param name="previousFailureLog">The previous failure log</param>
        /// <returns>A list of Test Case IDs that are failing only in the latest run</returns>
        public static List<string> GetNewFailures(string latestFailureLog, string previousFailureLog)
        {
            var latestFailures = GetFailedTestCaseIds(latestFailureLog);
            var previousFailures = GetFailedTestCaseIds(previousFailureLog);

            // Compare latest failures with the failures on the run before that
            var newFailures = latestFailures.Where(failure => !previousFailures.Exists(x => x.Equals(failure))).ToList();

            OutputResultsListToConsole("New failures since the previous run: ", newFailures);

            return newFailures;
        }

        /// <summary>
        /// Gets Test Case IDs of failures that are in the previous failure log but not the latest.
        /// Writes the results to the console.
        /// </summary>
        /// <param name="latestFailureLog">The latest failure log</param>
        /// <param name="previousFailureLog">The previous failure log</param>
        /// <returns>A list of Test Case IDs that are failing in the previous run only</returns>
        public static List<string> GetFixedFailures(string latestFailureLog, string previousFailureLog)
        {

            var latestFailures = GetFailedTestCaseIds(latestFailureLog);
            var previousFailures = GetFailedTestCaseIds(previousFailureLog);

            // Compare previous failures with the latest run
            var fixedFailures = previousFailures.Where(failure => !latestFailures.Exists(y => y.Equals(failure))).ToList();

            OutputResultsListToConsole("Tests that are no longer failing: ", fixedFailures);

            return fixedFailures;
        }
    }
}
