using System;

namespace Day_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] splittedInput = System.IO.File.ReadAllText("input.txt").Split('\n');
            Console.WriteLine(ValidPasswords(splittedInput)); // solution for the first part
        }

        static Tuple<int, int, char, string> Separate(string passwordLine)
        {
            var buffer = String.Empty;
            int minNumber = 0, maxNumber = 0;
            var requiredLetter = '\0';

            foreach (var character in passwordLine)
            {
                switch (character)
                {
                    case '-':
                        minNumber = Convert.ToInt32(buffer);
                        buffer = String.Empty;
                        break;
                    case ' ':
                        if (maxNumber == 0)
                        {
                            maxNumber = Convert.ToInt32(buffer);
                            buffer = String.Empty;
                        }
                        else
                            buffer = String.Empty;
                        break;
                    case ':':
                        requiredLetter = buffer[0];
                        break;
                    default:
                        buffer += character;
                        break;
                }
            }

            return Tuple.Create(minNumber, maxNumber, requiredLetter, buffer);
        }

        static int ValidPasswords(string[] input)
        {
            var passwordCounter = 0;
            
            foreach (var passwordLine in input)
            {
                var separatedPasswordLine = Separate(passwordLine);
                var letterCounter = 0;

                foreach (var letter in separatedPasswordLine.Item4)
                {
                    if (letter == separatedPasswordLine.Item3)
                        letterCounter++;
                }

                if (letterCounter >= separatedPasswordLine.Item1 && letterCounter <= separatedPasswordLine.Item2)
                    passwordCounter++;
            }

            return passwordCounter;
        }
    }
}
