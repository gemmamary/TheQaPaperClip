using System;
using System.Collections.Generic;
using System.Text;

namespace AutoCompare
{
    public static class LogResults
    {
        /// <summary>
        /// Outputs a list of results to the console
        /// </summary>
        /// <param name="description">The description of the results being written to the console</param>
        /// <param name="results">The list of results to be written to the console</param>
        public static void OutputResultsListToConsole(string description, List<string> results)
        {
            Console.WriteLine(description);
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }

        /// <summary>
        /// Outputs a message to the console based on a condition
        /// </summary>
        /// <param name="condition">Takes either true or false</param>
        /// <param name="messageForTrue">The message to be written to the console if the condition is true</param>
        /// <param name="messageForFalse">The message to be written to the console if the condition is false</param>
        public static void OutputResultsToConsole(bool condition, string messageForTrue, string messageForFalse)
        {
            if (condition)
            {
                Console.WriteLine(messageForTrue);
            }
            else
            {
                Console.WriteLine(messageForFalse);
            }
        }
    }
}
