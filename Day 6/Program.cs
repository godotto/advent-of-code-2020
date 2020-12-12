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
            Console.WriteLine(RevisedYesAnswered(splittedInput)); // solution to part two
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

        static int GetGropupLength(string group) // returns number of people in a group
        {
            return group.Split('\n').GetLength(0);
        }

        static int RevisedYesAnswered(string[] input)
        {
            var answeredQuestions = new Dictionary<char, int>(); // contains number of answered question for every possible question
            var answeredCount = 0;

            for (var c = 'a'; c <= 'z'; c++) // fills dictionary with the alphabet which represents every possible question
                answeredQuestions.Add(c, 0);

            foreach (var group in input)
            {
                var groupLength = GetGropupLength(group);

                foreach (var question in group)
                {
                    if (Char.IsLower(question))
                        answeredQuestions[question]++;
                }

                for (var c = 'a'; c <= 'z'; c++)
                {
                    if (answeredQuestions[c] == groupLength) // increments only if a question has been answered by every member of a group
                        answeredCount++;
                    answeredQuestions[c] = 0;
                }
            }
            return answeredCount;
        }
    }
}