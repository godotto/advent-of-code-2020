using System;

namespace Day_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var splittedInput = System.IO.File.ReadAllText("input.txt").Split("\n");
            Console.WriteLine(HighestSeatId(splittedInput)); // solution for part one
        }

        /* As airline uses binary space partitioning, I have found out that we can easily translate
        the codes from boarding passes to binary numbers (each operation on seats can be represented
        as a bit) - first seven bits yield a row number and the three bits yield a column number.
        Note: the code consists of two binary words, not one long*/
        static string TranslateLetterCodeToBin(string letterCode) 
        {
            letterCode = letterCode.Replace('F', '0'); // take the lower half rows
            letterCode = letterCode.Replace('B', '1'); // take the higher half rows
            letterCode = letterCode.Replace('L', '0'); // take the lower half columns
            letterCode = letterCode.Replace('R', '1'); // take the higher half columns

            return letterCode;
        }

        static int HighestSeatId(string[] input)
        {
            var maxId = 0;

            foreach (var boardingPass in input)
            {
                /* the following lines take the proper fragment of letter code, translate them to
                binary encoding and than convert to int values*/
                var row = Convert.ToInt32(TranslateLetterCodeToBin(boardingPass.Substring(0, 7)), 2);
                var column = Convert.ToInt32(TranslateLetterCodeToBin(boardingPass.Substring(7)), 2);

                var seatId = row * 8 + column; // 8 is a number given in task to generate id, it has no special meaning
                maxId = seatId > maxId ? seatId : maxId;
            }

            return maxId;
        }
    }
}
