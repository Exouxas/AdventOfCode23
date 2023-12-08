﻿namespace AdventOfCode23
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
            ];

            for(int i = 0; i < solvers.Count; i++)
            {
                Console.WriteLine($"Day {i + 1}, part 1: {solvers[i].GetPuzzleOutput1()}, part 2: {solvers[i].GetPuzzleOutput2()}");
            }
        }
    }
}
