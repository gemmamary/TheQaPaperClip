# TheQaPaperClip

Prereqs:
Ensure you have DotNetCore installed and updated to version 5 or later.

### AutoCompare

The AutoCompare project contains a console application that will compare failure logs from two different runs.

Setup: 
- Clone the repo onto your local machine
- Remove example logs in the 'FailureLogs' folder in the repo (Note: Failure logs will need to be in this format currently)
- Add your own failure logs to the 'FailureLogs' folder in the repo
- Add the date of the test run to each failure log (e.g. 'Failure_03082021' is the failure log for 3rd August 2021)
- Update the Test Case prefix in 'FailedTests.cs' for getting test case IDs
- Update the index for where the test name starts in 'FailedTests.cs'

Output:
- Line stating whether there are any differences between the two files
- Test Case IDs of new failures (failures that are in the latest run but not the previous)
- Test Case IDs of fixed failures (failures that are in the previous run but not in the latest)





