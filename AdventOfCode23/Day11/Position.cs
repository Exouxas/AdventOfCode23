using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode23.Day11
{
    internal class Position(int x, int y)
    {
        public int X { get; set; } = x;
        public int Y { get; set; } = y;

        public int DistanceTo(Position p2)
        {
            int xdist = Math.Abs(p2.X - X);
            int ydist = Math.Abs(p2.Y - Y);

            return Math.Max(xdist + ydist, 0);
        }
    }
}
