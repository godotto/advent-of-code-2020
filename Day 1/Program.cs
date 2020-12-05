using System;
using System.Collections.Generic;

namespace Day_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] splittedInput = System.IO.File.ReadAllText("input.txt").Split('\n');
            Console.WriteLine(SumTwoTo2020(splittedInput)); // solution for part one
            Console.WriteLine(SumThreeTo2020(splittedInput)); // solution for part two
        }

        static int SumTwoTo2020(string[] input)                         // it is a two-sum problem which can be solved with dictionary/hash table
        {                                                               // we're looking for two numbers of which sum will be equal to 2020
            Dictionary<int, int> existingNumbers = new Dictionary<int, int>();

            for (var i = 0; i < input.Length; i++)
            {
                var convertedString = Convert.ToInt32(input[i]);
                existingNumbers.Add(convertedString, i);            // dictionary contains input values as the keys and indices of those input values as the dictionary's values

                var difference = 2020 - convertedString; //  difference between 2020 (which we want to obtain via adding to values) and current value from input
                if (existingNumbers.ContainsKey(difference))        // if dictionary contains number equal to that difference it means we have a match
                    return convertedString * Convert.ToInt32(input[existingNumbers[difference]]); // return those two numbers multiplied
            }

            return -1; // return an error code if there are no numbers fulfilling the condition
        }

        static int SumThreeTo2020(string[] input) // this time we deal with a three-sum problem
        {
            for (var i = 0; i < input.Length; i++)
            {
                var convertedString = Convert.ToInt32(input[i]);
                var firstDifference = 2020 - convertedString; // difference between 2020 and current value from input

                List<int> existingNumbers = new List<int>(); // list for tracking numbers form input that have been already read

                for (var j = i + 1; j < input.Length; j++) // another loop as we need to find a sum of three (thus its complexity is O(n^2)) 
                {
                    convertedString = Convert.ToInt32(input[j]);
                    var secondDifference = firstDifference - convertedString; // difference between previous difference and current value from input

                    if (existingNumbers.Contains(secondDifference)) // if list contains a number equal to difference between previous difference and current value from input it means we have a match
                        return secondDifference * Convert.ToInt32(input[i]) * Convert.ToInt32(input[j]); // return all three elements of sum multiplied
                    else
                        existingNumbers.Add(Convert.ToInt32(convertedString));
                }
            }

            return -1; // return an error code if there are no numbers fulfilling the condition
        }
    }
}
