using System.Diagnostics;

namespace AdventOfCode23.Day14
{
    internal class Solver : AdventSolver
    {
        public override string GetPuzzleOutput1()
        {
            int[] loadCounter = new int[puzzleInput[0].Length];
            for(int i = 0; i < loadCounter.Length; i++)
            {
                loadCounter[i] = Load(0);
            }

            long sum = 0;

            for(int y = 0; y < puzzleInput.Length; y++)
            {
                for(int x = 0; x < puzzleInput[y].Length; x++)
                {
                    if (puzzleInput[y][x] == '#')
                    {
                        loadCounter[x] = Load(y + 1);
                    }
                    else if(puzzleInput[y][x] == 'O')
                    {
                        sum += loadCounter[x];
                        loadCounter[x]--;
                    }
                }
            }



            return sum.ToString();
        }

        public override string GetPuzzleOutput2()
        {
            return "ERR";
        }

        private int Load(int position)
        {
            return puzzleInput.Length - position;
        }

        protected override string GetFolderName()
        {
            return "Day14";
        }
    }
}
