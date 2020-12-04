using System;
using System.Collections.Generic;

namespace Day_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] splittedInput = System.IO.File.ReadAllText("input.txt").Split('\n');
            Console.WriteLine(SumTo2020(splittedInput)); // solution for part one
        }

        static int SumTo2020(string[] input)                            // it is a two-sum problem which can be solved with dictionary/hash table
        {                                                               // we're looking for two numbers of which sum will be equal to 2020
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (var i = 0; i < input.Length; i++)
            {
                var convertedString = Convert.ToInt32(input[i]);
                dict.Add(convertedString, i);             // dictionary contains input values as the keys and indices of those input values as the dictionary's values

                var difference = 2020 - convertedString; //  difference between 2020 (which we want to obtain via adding to values) and current value from input
                if (dict.ContainsKey(difference))        // if dictionary contains number equal to that difference it means we have a match
                    return convertedString * Convert.ToInt32(input[dict[difference]]); // return those two numbers multiplied
            }

            return -1; // return an error code if there are no numbers fulfilling the condition
        }
    }
}
