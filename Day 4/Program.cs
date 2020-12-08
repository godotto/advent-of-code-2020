using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var splittedInput = System.IO.File.ReadAllText("input.txt").Split("\n\n");
            Console.WriteLine(ValidPassports(splittedInput)); // solution for part two (and for part one for the previous version of code)
        }

        static int ValidPassports(string[] input)
        {
            var debug = new List<string>();
            
            var numberOfValid = 0;
            var fieldsRegexes = new Dictionary<string, Regex>() // possible names of passport fields and regexes which are accepting them
            {
                {"byr", new Regex("19[2-9][0-9]|200[0-2]")},
                {"iyr", new Regex("20(1[0-9]|20)")},
                {"eyr", new Regex("20(2[0-9]|30)")},
                {"hgt", new Regex("1([5-8][0-9]|9[0-3])cm|(59|6[0-9]|7[0-6])in")},
                {"hcl", new Regex("#([0-9]|[a-f]){6}")},
                {"ecl", new Regex("amb|blu|brn|gry|grn|hzl|oth")}
            };

            foreach (var passport in input)
            {
                var splittedPassport = passport.Split(' ', '\n'); // split all entries of each passport
                if ((splittedPassport.Any(s => s.Contains("cid")) || splittedPassport.Length != 7) && splittedPassport.Length != 8) // 
                    continue;

                var areFieldsValid = true;

                foreach (var field in splittedPassport)
                {
                    var fieldName = field.Substring(0, 3);
                    var fieldValue = field.Substring(4);

                    /* as the regular expression "[0-9]{9}" didn't work properly for me I had
                    to use the following ugly workaround; it is also not possible to combine the second and
                    the third if statement as fieldsRegexes doesn't contain the key "pid"*/

                    if (fieldName == "cid" || (fieldName == "pid" && fieldValue.Length == 9))
                        continue;
                    else if (fieldName == "pid" && fieldValue.Length != 9)
                    {
                        areFieldsValid = false;
                        break;
                    }

                    if (!fieldsRegexes[fieldName].IsMatch(fieldValue))
                    {
                        areFieldsValid = false;
                        break;
                    }
                }

                if (areFieldsValid)
                    numberOfValid++;
            }

            return numberOfValid;
        }
    }
}
