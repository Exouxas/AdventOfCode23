using System.Diagnostics;

namespace AdventOfCode23.Day01
{
    internal class Solver : AdventSolver
    {
        public override string GetPuzzleOutput1()
        {
            int sum = 0;

            foreach(string line in puzzleInput)
            {
                char firstDigit = '0';
                char lastDigit = '0';

                foreach(char c in line)
                {
                    if(c >= '0' && c <= '9')
                    {
                        firstDigit = c;
                        break;
                    }
                }

                IEnumerable<char> reversedLine = line.Reverse();

                foreach (char c in reversedLine)
                {
                    if (c >= '0' && c <= '9')
                    {
                        lastDigit = c;
                        break;
                    }
                }

                sum += (firstDigit - '0') * 10 + lastDigit - '0';
            }

            return sum.ToString();
        }

        public override string GetPuzzleOutput2()
        {
            int sum = 0;

            char[][] numbers =
            [
                ['1'],
                ['2'],
                ['3'],
                ['4'],
                ['5'],
                ['6'],
                ['7'],
                ['8'],
                ['9'],
                ['o', 'n', 'e'],
                ['t', 'w', 'o'],
                ['t', 'h', 'r', 'e', 'e'],
                ['f', 'o', 'u', 'r'],
                ['f', 'i', 'v', 'e'],
                ['s', 'i', 'x'],
                ['s', 'e', 'v', 'e', 'n'],
                ['e', 'i', 'g', 'h', 't'],
                ['n', 'i', 'n', 'e']
            ];

            char[][] reverseNumbers = new char[numbers.Length][];
            for(int i = 0; i < reverseNumbers.Length; i++)
            {
                reverseNumbers[i] = numbers[i].Reverse().ToArray();
            }

            foreach (string line in puzzleInput)
            {
                char[] chars = line.ToCharArray();
                char[] reverseChars = chars.Reverse().ToArray();

                char[] firstMatch = FirstMatch(chars, numbers);
                char[] lastMatch = FirstMatch(reverseChars, reverseNumbers).Reverse().ToArray();

                sum += ToNumber(new string(firstMatch)) * 10 + ToNumber(new string(lastMatch));
            }

            return sum.ToString();
        }

        private int ToNumber(string s)
        {
            switch (s)
            {
                case "1": case "one":
                    return 1;

                case "2": case "two":
                    return 2;

                case "3": case "three":
                    return 3;

                case "4": case "four":
                    return 4;

                case "5": case "five":
                    return 5;

                case "6": case "six":
                    return 6;

                case "7": case "seven":
                    return 7;

                case "8": case "eight":
                    return 8;

                case "9": case "nine":
                    return 9;


                default: return 0;
            }
        }

        private static char[] FirstMatch(char[] s, char[][] sets)
        {
            for(int pointer = 0; pointer < s.Count(); pointer++) 
            {
                foreach(char[] set in sets)
                {
                    bool isValid = true;

                    for(int i = 0; i < set.Count(); i++)
                    {
                        if (s[pointer + i] != set[i])
                        {
                            isValid = false;
                            break;
                        }
                    }

                    // If it matches:
                    if(isValid) return set;
                }
            }

            throw new Exception("No matches");
        }

        protected override string GetFolderName()
        {
            return "Day01";
        }
    }
}
