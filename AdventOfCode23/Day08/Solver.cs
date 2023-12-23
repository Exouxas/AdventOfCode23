using System.Diagnostics;

namespace AdventOfCode23.Day08
{
    internal class Solver : AdventSolver
    {
        public override string GetPuzzleOutput1()
        {
            Dictionary<string, string[]> pairs = CatalogLRItems();

            string location = "AAA";
            int steps = 0;
            string directions = puzzleInput[0];

            while (!location.Equals("ZZZ"))
            {
                steps++;

                if (directions[(steps - 1) % directions.Length] == 'L')
                {
                    location = pairs[location][0];
                }
                else
                {
                    location = pairs[location][1];
                }
            }

            return steps.ToString();
        }

        public override string GetPuzzleOutput2()
        {
            return "ERR";
            Dictionary<string, string[]> pairs = CatalogLRItems();

            List<string> locations = new();
            int steps = 0;
            string directions = puzzleInput[0];

            foreach(string s in pairs.Keys)
            {
                if (s[2] == 'A') locations.Add(s);
            }

            bool sync = false;

            while (!sync)
            {
                steps++;

                List<string> locations2 = new();
                if (directions[(steps - 1) % directions.Length] == 'L')
                {
                    foreach(string s in locations) locations2.Add(pairs[s][0]);
                }
                else
                {
                    foreach (string s in locations) locations2.Add(pairs[s][1]);
                }

                locations = locations2;

                // Breakout check
                sync = true;
                foreach(string s in locations)
                {
                    if (s[2] != 'Z')
                    {
                        sync = false;
                        break;
                    }
                }
            }

            return steps.ToString();
        }

        private Dictionary<string, string[]> CatalogLRItems()
        {
            Dictionary<string, string[]> pairs = new();

            foreach(string line in puzzleInput)
            {
                if (!line.Contains("=")) continue;

                string[] split1 = Clean(line).Split("=");
                string[] split2 = split1[1].Split(",");

                string source = split1[0];
                string left = split2[0];
                string right = split2[1];

                pairs.Add(source, [left, right]);
            }

            return pairs;
        }

        private static string Clean(string input)
        {
            return input.Replace(" ", "").Replace("(", "").Replace(")", "");
        }

        protected override string GetFolderName()
        {
            return "Day08";
        }
    }
}
