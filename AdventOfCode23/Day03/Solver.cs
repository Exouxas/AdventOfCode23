using System.Diagnostics;

namespace AdventOfCode23.Day03
{
    internal class Solver : AdventSolver
    {
        public override string GetPuzzleOutput1()
        {
            int sum = 0;

            int number = 0;
            bool readNumber = false;
            bool validNumber = false;


            for(int y = 0; y < puzzleInput.Length; y++)
            {
                for(int x = 0; x < puzzleInput[y].Length; x++)
                {
                    char c = puzzleInput[y][x];

                    if (!readNumber)
                    {
                        if (IsDigit(c)) // If it's a number
                        {
                            number = 0;
                            readNumber = true;
                            validNumber = false;
                        }
                    }

                    if (readNumber)
                    {
                        if(!IsDigit(c)) // If it's not a number
                        {
                            // Finish the number
                            if (validNumber)
                            {
                                sum += number;
                            }

                            readNumber = false;
                        }
                        else // If it's a number
                        {
                            // Add digit
                            number *= 10;
                            number += c - '0';

                            // Check validity
                            validNumber = validNumber || CheckValid(x, y, puzzleInput);
                        }
                    }
                }
            }


            return sum.ToString();
        }

        private static bool CheckValid(int x, int y, string[] map)
        {
            if (IsSymbol(x, y - 1, map)) return true;
            if (IsSymbol(x, y + 1, map)) return true;
            if (IsSymbol(x - 1, y, map)) return true;
            if (IsSymbol(x + 1, y, map)) return true;

            if (IsSymbol(x - 1, y - 1, map)) return true;
            if (IsSymbol(x + 1, y - 1, map)) return true;
            if (IsSymbol(x - 1, y + 1, map)) return true;
            if (IsSymbol(x + 1, y + 1, map)) return true;

            return false;
        }

        private static bool IsSymbol(int x, int y, string[] map)
        {
            if(y < 0 || y >= map.Length) return false;
            if(x < 0 || x >= map[0].Length) return false;

            char c = map[y][x];

            return !(IsDigit(c) || c == '.');
        }

        private static bool IsDigit(char c)
        {
            return c >= '0' && c <= '9';
        }

        private static bool IsDigit(int x, int y, string[] map)
        {
            if (y < 0 || y >= map.Length) return false;
            if (x < 0 || x >= map[0].Length) return false;

            char c = map[y][x];

            return IsDigit(c);
        }

        public override string GetPuzzleOutput2()
        {
            int sum = 0;

            for (int y = 0; y < puzzleInput.Length; y++)
            {
                for (int x = 0; x < puzzleInput[y].Length; x++)
                {
                    if(puzzleInput[y][x] == '*') // If it's a gear
                    {
                        int adjecentNumbers = 0;
                        int adjecentProduct = 1;

                        // Check top
                        if (IsDigit(x, y - 1, puzzleInput))
                        {
                            adjecentNumbers++;
                            adjecentProduct *= GrabNumber(x, y - 1, puzzleInput);
                        }
                        else
                        {
                            // Top left
                            if (IsDigit(x - 1, y - 1, puzzleInput))
                            {
                                adjecentNumbers++;
                                adjecentProduct *= GrabNumber(x - 1, y - 1, puzzleInput);
                            }

                            // Top right
                            if (IsDigit(x + 1, y - 1, puzzleInput))
                            {
                                adjecentNumbers++;
                                adjecentProduct *= GrabNumber(x + 1, y - 1, puzzleInput);
                            }
                        }

                        // Check bottom
                        if (IsDigit(x, y + 1, puzzleInput))
                        {
                            adjecentNumbers++;
                            adjecentProduct *= GrabNumber(x, y + 1, puzzleInput);
                        }
                        else
                        {
                            // Bottom left
                            if (IsDigit(x - 1, y + 1, puzzleInput))
                            {
                                adjecentNumbers++;
                                adjecentProduct *= GrabNumber(x - 1, y + 1, puzzleInput);
                            }

                            // Bottom right
                            if (IsDigit(x + 1, y + 1, puzzleInput))
                            {
                                adjecentNumbers++;
                                adjecentProduct *= GrabNumber(x + 1, y + 1, puzzleInput);
                            }
                        }

                        // Check left
                        if (IsDigit(x - 1, y, puzzleInput))
                        {
                            adjecentNumbers++;
                            adjecentProduct *= GrabNumber(x - 1, y, puzzleInput);
                        }

                        // Check right
                        if (IsDigit(x + 1, y, puzzleInput))
                        {
                            adjecentNumbers++;
                            adjecentProduct *= GrabNumber(x + 1, y, puzzleInput);
                        }

                        if (adjecentNumbers == 2) sum += adjecentProduct;
                    }
                }
            }

            return sum.ToString();
        }

        private static int GrabNumber(int x, int y, string[] map)
        {
            // If out of bounds
            if (y < 0 || y >= map.Length) return 0;
            if (x < 0 || x >= map[0].Length) return 0;

            // If character is not a digit
            if (!IsDigit(map[y][x])) return 0;

            // Find first digit
            int pointer = x;
            while(pointer > 0 && IsDigit(map[y][pointer - 1])) // Move left to the beginning of the number
            {
                pointer--;
            }

            // Construct number
            int number = 0;
            while (pointer < map[y].Length && IsDigit(map[y][pointer]))
            {
                number *= 10;
                number += map[y][pointer] - '0';
                pointer++;
            }

            return number;
        }

        protected override string GetFolderName()
        {
            return "Day03";
        }
    }
}
