using System.Diagnostics;

namespace AdventOfCode23.Day09
{
    internal class Solver : AdventSolver
    {
        public override string GetPuzzleOutput1()
        {
            long sum = 0;

            foreach(string line in puzzleInput)
            {
                sum += NextNumber(ToInt(line.Split(' ')));
            }

            return sum.ToString();
        }

        public override string GetPuzzleOutput2()
        {
            long sum = 0;

            foreach (string line in puzzleInput)
            {
                sum += PreviousNumber(ToInt(line.Split(' ')));
            }

            return sum.ToString();
        }

        private static int[] ToInt(string[] text)
        {
            int[] result = new int[text.Length];
            for(int i = 0; i < result.Length; i++)
            {
                result[i] = int.Parse(text[i]);
            }

            return result;
        }

        private static int NextNumber(int[] numbers)
        {
            int next = numbers.Last();
            int[] currentSequence = numbers;

            while (!IsZero(currentSequence))
            {
                int[] numbers2 = new int[currentSequence.Length - 1];

                for(int i = 0; i < numbers2.Length; i++)
                {
                    numbers2[i] = currentSequence[i + 1] - currentSequence[i];
                }

                next += numbers2.Last();
                currentSequence = numbers2;
            }

            return next;
        }

        private static int PreviousNumber(int[] numbers)
        {
            List<int[]> sequences = new();
            sequences.Add(numbers);

            while (!IsZero(sequences.Last()))
            {
                int[] numbers2 = new int[sequences.Last().Length - 1];

                for (int i = 0; i < numbers2.Length; i++)
                {
                    numbers2[i] = sequences.Last()[i + 1] - sequences.Last()[i];
                }

                sequences.Add(numbers2);
            }

            sequences.Reverse();

            int previous = 0;
            foreach (int[] numbers2 in sequences)
            {
                previous = numbers2[0] - previous;
            }

            return previous;
        }

        private static bool IsZero(int[] numbers)
        {
            foreach(int n in numbers)
            {
                if (n != 0) return false;
            }

            return true;
        }

        protected override string GetFolderName()
        {
            return "Day09";
        }
    }
}
