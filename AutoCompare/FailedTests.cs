using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AutoCompare
{
    public class FailedTests
    {

        // Returns the Test Case Names of all failed test cases in a given log
        public static List<string> GetFailedTestCaseNames(string failureLog)
        {
            IEnumerable<string> failures = File.ReadLines(failureLog);

            return (from failure in failures
                    select failure[29..]).ToList();
        }

        // Returns the Test Case IDs of all failed test cases in a given log
        public static List<string> GetFailedTestCaseIds(string failureLog)
        {
            IEnumerable<string> failures = File.ReadLines(failureLog);

            return (from failure in failures
                    let idIndex = failure.IndexOf("TC")
                    select failure[idIndex..]).ToList();
        }

        // Returns the number of failed test cases in a given log
        public static int GetFailedTestCaseCount(string failureLog)
        {
            IEnumerable<string> failures = File.ReadLines(failureLog);

            return failures.Count();
        }
    }
}
