using System;
using System.Collections.Generic;

namespace Day_6
{
    class Program
    {
        static void Main(string[] args)
        {
            var splittedInput = System.IO.File.ReadAllText("input.txt").Split("\n\n");
            Console.WriteLine(YesAnswers(splittedInput)); // solution to part one
        }

        static int YesAnswers(string[] input)
        {
            var answeredQuestions = new List<char>();
            var answeredCount = 0;

            foreach (var group in input)
            {
                foreach (var question in group)
                {
                    if (!answeredQuestions.Contains(question) && Char.IsLower(question))
                        answeredQuestions.Add(question); // it contains only unique occurances of questions
                }
                answeredCount += answeredQuestions.Count;
                answeredQuestions.Clear(); // clear before checking next group
            }
            return answeredCount;
        }
    }
}