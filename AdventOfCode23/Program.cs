namespace AdventOfCode23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<AdventSolver> solvers =
            [
                new Day01.Solver(),
                new Day02.Solver(),
                new Day03.Solver(),
                new Day04.Solver(),
                new Day05.Solver(),
                new Day06.Solver(),
                new Day07.Solver(),
                new Day08.Solver(),
                new Day09.Solver(),
                new Day10.Solver(),
                new Day11.Solver(),
                new Day12.Solver(),
                new Day13.Solver(),
                new Day14.Solver(),
                new Day15.Solver(),
                new Day16.Solver(),
                new Day17.Solver(),
                new Day18.Solver(),
                new Day19.Solver(),
                new Day20.Solver(),
                new Day21.Solver(),
                new Day22.Solver(),
                new Day23.Solver(),
                new Day24.Solver(),
                new Day25.Solver(),
            ];

            for(int i = 0; i < solvers.Count; i++)
            {
                Console.WriteLine($"Day {i + 1}, part 1: {solvers[i].GetPuzzleOutput1()}, part 2: {solvers[i].GetPuzzleOutput2()}");
            }
        }
    }
}
