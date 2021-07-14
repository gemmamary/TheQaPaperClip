using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AutoCompare
{
    public class FailedTests
    {

        /// <summary>
        /// Gets the full names of the failed test cases in a log
        /// </summary>
        /// <param name="failureLog">The log to retrieve test case names from</param>
        /// <returns>A list of Failed Test Case names</returns>
        public static List<string> GetFailedTestCaseNames(string failureLog)
        {
            IEnumerable<string> failures = File.ReadLines(failureLog);

            return (from failure in failures
                    select failure[29..]).ToList();
        }

        /// <summary>
        /// Gets the IDs of the failed test cases in a log
        /// </summary>
        /// <param name="failureLog">The log to retrieve test case IDs from</param>
        /// <returns>A list of Failed Test Case IDs</returns>
        public static List<string> GetFailedTestCaseIds(string failureLog)
        {
            IEnumerable<string> failures = File.ReadLines(failureLog);

            return (from failure in failures
                    let idIndex = failure.IndexOf("TC")
                    select failure[idIndex..]).ToList();
        }

        /// <summary>
        /// Get the number of failed test cases given in a log
        /// </summary>
        /// <param name="failureLog">The log to count failures from</param>
        /// <returns>The number of failures in a failure log</returns>
        public static int GetFailedTestCaseCount(string failureLog)
        {
            IEnumerable<string> failures = File.ReadLines(failureLog);

            return failures.Count();
        }
    }
}
