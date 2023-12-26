using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode23.Day15
{
    internal class Lens(string label, int focus)
    {
        public string Label { get; set; } = label;
        public int Focus { get; set; } = focus;
    }
}
