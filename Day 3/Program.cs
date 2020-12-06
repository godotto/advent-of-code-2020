using System;

namespace Day_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] splittedInput = System.IO.File.ReadAllText("input.txt").Split('\n');
            Console.WriteLine(TreeEncounters(splittedInput, 3, 1));                                 // solution for part one
            Console.WriteLine(MultiplyAllEncounters(splittedInput, 1, 1, 3, 1, 5, 1, 7, 1, 1, 2));  // solution for part two
        }

        static int TreeEncounters(string[] input, int rightSlope, int downSlope) // returns number of encountered trees for given slopes
        {
            var yPosition = 0; // keeps track on a horizontal index of input lines
            var treeCounter = 0;

            for (var i = 0; i < input.Length; i += downSlope)
            {
                if (input[i][yPosition] == '#')
                    treeCounter++;

                yPosition = (yPosition += rightSlope) > (input[i].Length - 1) ? yPosition - input[i].Length : yPosition; // if next position exceeds the length of line it goes back
            }

            return treeCounter;
        }

        static long MultiplyAllEncounters(string[] input, params int[] slopes) // slopes have to be given in pairs (right slope, down slope, right slope, down slope, ...)
        {
            var result = 1L;

            for (var i = 0; i < slopes.Length; i += 2)
                result *= TreeEncounters(input, slopes[i], slopes[i + 1]);

            return result;
        }
    }
}
