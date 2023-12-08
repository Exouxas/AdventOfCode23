using System.Diagnostics;

namespace AdventOfCode23.Day02
{
    internal class Solver : AdventSolver
    {
        public override string GetPuzzleOutput1()
        {
            int sum = 0;
            foreach(string line in puzzleInput)
            {
                sum += Validate(line, 12, 13, 14);
            }

            return sum.ToString();
        }

        private int Validate(string line, int r, int g, int b)
        {
            string[] info = line.Split(": ");
            int id = int.Parse(info[0].Split(" ")[1]);
            info[1] = info[1].Replace(";", ",");
            string[] draws = info[1].Split(", ");

            foreach (string draw in draws) 
            {
                string[] drawPart = draw.Split(" ");
                string color = drawPart[1];
                int amount = int.Parse(drawPart[0]);

                if (color.Equals("red") && amount > r) return 0;
                if (color.Equals("green") && amount > g) return 0;
                if (color.Equals("blue") && amount > b) return 0;
            }

            return id;
        }

        private int Least(string line)
        {
            string[] info = line.Split(": ");
            int id = int.Parse(info[0].Split(" ")[1]);
            info[1] = info[1].Replace(";", ",");
            string[] draws = info[1].Split(", ");

            int r = 0;
            int g = 0;
            int b = 0;

            foreach (string draw in draws)
            {
                string[] drawPart = draw.Split(" ");
                string color = drawPart[1];
                int amount = int.Parse(drawPart[0]);

                if (color.Equals("red") && amount > r) r = amount;
                if (color.Equals("green") && amount > g) g = amount;
                if (color.Equals("blue") && amount > b) b = amount;
            }

            return r * g * b;
        }

        public override string GetPuzzleOutput2()
        {
            int sum = 0;
            foreach (string line in puzzleInput)
            {
                sum += Least(line);
            }

            return sum.ToString();
        }

        protected override string GetFolderName()
        {
            return "Day02";
        }
    }
}
