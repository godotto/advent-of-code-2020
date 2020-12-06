using System;

namespace Day_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] splittedInput = System.IO.File.ReadAllText("input.txt").Split('\n');
            Console.WriteLine(ValidPasswordsObsolete(splittedInput)); // solution for the first part
            Console.WriteLine(ValidPasswords(splittedInput)); // solution for the second part
        }

        static Tuple<int, int, char, string> Separate(string passwordLine)  // separating info from a single line of input to a tuple
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

        static int ValidPasswordsObsolete(string[] input) // counting passwords that have given number of ocurrences of a certain characters
        {
            var passwordCounter = 0;

            foreach (var passwordLine in input)
            {
                var separatedPasswordLine = Separate(passwordLine);
                var letterCounter = 0;

                foreach (var letter in separatedPasswordLine.Item4) // loop counting number of ocurrences of a character
                {
                    if (letter == separatedPasswordLine.Item3) 
                        letterCounter++;
                }

                if (letterCounter >= separatedPasswordLine.Item1 && letterCounter <= separatedPasswordLine.Item2) // checking if number of ocurrences fulfills the condition
                    passwordCounter++;
            }

            return passwordCounter;
        }

        static int ValidPasswords(string[] input) // counting passwords that have a certain character in one (and only one) of given positions  
        {
            var passwordCounter = 0;

            foreach (var passwordLine in input)
            {
                var separatedPasswordLine = Separate(passwordLine);

                if ((separatedPasswordLine.Item4[separatedPasswordLine.Item1 - 1] == separatedPasswordLine.Item3)
                    != (separatedPasswordLine.Item4[separatedPasswordLine.Item2 - 1] == separatedPasswordLine.Item3))
                    passwordCounter++;
            }

            return passwordCounter;
        }
    }
}
