using System;

namespace Day_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] splittedInput = System.IO.File.ReadAllText("input.txt").Split('\n');
            Console.WriteLine(TreeEncounters(splittedInput)); // solution for part one
        }

        static int TreeEncounters(string[] input) // returns number of encountered trees assuming the slope right 3, down 1
        {
            var yPosition = 0; // keeps track on a horizontal index of input lines
            var treeCounter = 0;
            
            foreach (var line in input)
            {
                if (line[yPosition] == '#')
                    treeCounter++;

                yPosition = (yPosition += 3) > (line.Length - 1) ? yPosition - line.Length : yPosition; // if next position exceeds the length of line it goes back
            }

            return treeCounter;
        }
    }
}
