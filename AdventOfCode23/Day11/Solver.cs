using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.Intrinsics.Arm;

namespace AdventOfCode23.Day11
{
    internal class Solver : AdventSolver
    {
        public override string GetPuzzleOutput1()
        {
            List<Position> positions = Positions(puzzleInput);
            ExpandPositions(positions, puzzleInput, 1);

            List<Tuple<Position, Position>> pairs = UniquePairs(positions);

            long sum = 0;

            foreach(var pair in pairs)
            {
                sum += pair.Item1.DistanceTo(pair.Item2);
            }


            return sum.ToString();
        }

        public override string GetPuzzleOutput2()
        {
            List<Position> positions = Positions(puzzleInput);
            ExpandPositions(positions, puzzleInput, 999999);

            List<Tuple<Position, Position>> pairs = UniquePairs(positions);

            long sum = 0;

            foreach (var pair in pairs)
            {
                sum += pair.Item1.DistanceTo(pair.Item2);
            }


            return sum.ToString();
        }

        private List<Position> Positions(string[] map)
        {
            List<Position> positions = new();

            for(int y = 0; y < map.Length; y++)
            {
                for(int x = 0; x < map[y].Length; x++)
                {
                    if (map[y][x] == '#')
                    {
                        positions.Add(new Position(x, y));
                    }
                }
            }

            return positions;
        }

        private void ExpandPositions(List<Position> positions, string[] map, int amount)
        {
            List<int> emptyColumns = new();
            List<int> emptyRows = new();

            // Find empty columns
            for (int x = 0; x < map[0].Length; x++)
            {
                bool canExpand = true;
                for (int y = 0; y < map.Length; y++)
                {
                    if (map[y][x] == '#')
                    {
                        canExpand = false;
                        break;
                    }
                }

                if (canExpand)
                {
                    emptyColumns.Add(x);
                }
            }

            // Find empty rows
            for(int y = 0; y < map.Length; y++)
            {
                if (!map[y].Contains("#"))
                {
                    emptyRows.Add(y);
                }
            }


            emptyColumns.Reverse();
            emptyRows.Reverse();



            foreach (Position pos in positions)
            {
                foreach (int x in emptyColumns)
                {
                    if (pos.X > x) pos.X += amount;
                }

                foreach (int y in emptyRows)
                {
                    if (pos.Y > y) pos.Y += amount;
                }
            }
        }

        private List<Tuple<Position, Position>> UniquePairs(List<Position> positions)
        {
            List<Tuple<Position, Position>> pairs = new();

            for(int i = 0; i < positions.Count - 1; i++)
            {
                for(int i2 = i + 1; i2 < positions.Count; i2++)
                {
                    Tuple<Position, Position> pair = new(positions[i], positions[i2]);
                    pairs.Add(pair);
                }
            }


            return pairs;
        }

        protected override string GetFolderName()
        {
            return "Day11";
        }
    }
}
