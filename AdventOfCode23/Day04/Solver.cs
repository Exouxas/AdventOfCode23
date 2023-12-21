using System.Diagnostics;

namespace AdventOfCode23.Day04
{
    internal class Solver : AdventSolver
    {
        public override string GetPuzzleOutput1()
        {
            int sum = 0;
            foreach(string line in puzzleInput)
            {
                string[] sides = line.Replace("  ", " ").Split(": ")[1].Split(" | ");

                sum += Score(Matches(sides[0].Split(' '), sides[1].Split(' ')));
            }

            return sum.ToString();
        }

        public override string GetPuzzleOutput2()
        {
            int sum = 0;
            int[] amounts = new int[puzzleInput.Length];

            for(int i = 0; i < puzzleInput.Length; i++)
            {
                int matches = Score2(i);

                sum += amounts[i] + 1;

                for(int n = 1; n <= matches && n < amounts.Length - 1; n++)
                {
                    amounts[i + n] += amounts[i] + 1;
                }
            }

            return sum.ToString();
        }

        private int Score2(int index)
        {
            string[] sides = puzzleInput[index].Replace("  ", " ").Split(": ")[1].Split(" | ");
            int matches = Matches(sides[0].Split(' '), sides[1].Split(' '));

            return matches;
        }

        private int Score(int amount)
        {
            return (int)(Math.Pow(2, amount - 1));
        }

        private int Matches(string[] list1, string[] list2)
        {
            int count = 0;
            foreach(string i in list1)
            {
                if (list2.Contains(i)) count++;
            }

            return count;
        }

        protected override string GetFolderName()
        {
            return "Day04";
        }
    }
}
