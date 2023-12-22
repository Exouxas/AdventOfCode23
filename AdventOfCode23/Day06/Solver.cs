using System.Diagnostics;

namespace AdventOfCode23.Day06
{
    internal class Solver : AdventSolver
    {
        public override string GetPuzzleOutput1()
        {
            long[] times = Sanitize(puzzleInput[0]);
            long[] distances = Sanitize(puzzleInput[1]);

            long answer = 1;

            for(long i = 0; i < times.Length; i++)
            {
                answer *= CountValid(times[i], distances[i]);
            }


            return answer.ToString();
        }

        private long CountValid(long time, long distance)
        {
            for(long i = 0; i <= time / 2; i++)
            {
                if((time - i) * i > distance)
                {
                    return time - i * 2 + 1;
                }
            }

            return 0;
        }

        private long[] Sanitize(string input)
        {
            string singleSpaced = RemoveSpaces(input);
            string onlyNumbers = singleSpaced.Split(": ")[1];
            string[] separatedNumbers = onlyNumbers.Split(" ");

            return StringToInt(separatedNumbers);
        }

        private long[] StringToInt(string[] input)
        {
            long[] output = new long[input.Length];

            for(long i = 0; i < input.Length; i++)
            {
                output[i] = long.Parse(input[i]);
            }

            return output;
        }

        private string RemoveSpaces(string input)
        {
            string output = input;
            while(output.Contains("  "))
            {
                output = output.Replace("  ", " ");
            }

            return output;
        }

        public override string GetPuzzleOutput2()
        {
            long time = long.Parse(puzzleInput[0].Replace(" ", "").Split(":")[1]);
            long distance = long.Parse(puzzleInput[1].Replace(" ", "").Split(":")[1]);

            long answer = CountValid(time, distance);


            return answer.ToString();
        }

        protected override string GetFolderName()
        {
            return "Day06";
        }
    }
}
