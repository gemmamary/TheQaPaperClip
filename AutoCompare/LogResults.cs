using System;
using System.Collections.Generic;
using System.Text;

namespace AutoCompare
{
    public static class LogResults
    {
        public static void OutputResultsListToConsole(string description, List<string> results)
        {
            Console.WriteLine(description);
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }

        public static void OutputResultsToConsole(bool isTrue, string messageForTrue, string messageForFalse)
        {
            if (isTrue)
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
