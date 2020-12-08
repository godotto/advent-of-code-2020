using System;
using System.Linq;

namespace Day_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var splittedInput = System.IO.File.ReadAllText("input.txt").Split("\n\n");
            Console.WriteLine(ValidPassports(splittedInput)); // solution for part one
        }

        static int ValidPassports(string[] input)
        {
            var numberOfValid = 0;

            foreach (var passport in input)
            {
                var splittedPassport = passport.Split(' ', '\n'); // split all entries of each passport
                if ((!splittedPassport.Any(s => s.Contains("cid")) && splittedPassport.Length == 7) || splittedPassport.Length == 8)
                    numberOfValid++; // passport is valid if it contains all entries or is missing only a cid entry
            }

            return numberOfValid;
        }
    }
}
