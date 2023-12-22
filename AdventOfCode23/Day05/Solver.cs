using System.Diagnostics;

namespace AdventOfCode23.Day05
{
    internal class Solver : AdventSolver
    {
        public override string GetPuzzleOutput1()
        {
            List<MapConverter> maps = CreateConverters();
            long lowest = -1;

            foreach(string seed in puzzleInput[0].Split(": ")[1].Split(" "))
            {
                long location = long.Parse(seed);
                foreach (MapConverter map in maps)
                {
                    location = map.Convert(location);
                }

                if(lowest == -1 || location < lowest)
                {
                    lowest = location;
                }
            }


            return lowest.ToString();
        }

        private List<MapConverter> CreateConverters()
        {
            List<MapConverter> returnList = new();
            MapConverter currentMap = null;

            for(int i = 2; i < puzzleInput.Length; i++)
            {
                if (puzzleInput[i].Length == 0) continue; // Empty line
                if (puzzleInput[i].Contains(':')) // New set!
                {
                    currentMap = new();
                    returnList.Add(currentMap);
                }
                else // Content for current map!
                {
                    currentMap.Add(puzzleInput[i]);
                }
            }


            return returnList;
        }

        public override string GetPuzzleOutput2()
        {
            List<MapConverter> maps = CreateConverters();
            maps.Reverse();

            string[] seeds = puzzleInput[0].Split(": ")[1].Split(" ");

            int i = -1;
            bool finished = false;
            while (!finished)
            {
                i++;

                long location = i;

                foreach (MapConverter map in maps)
                {
                    location = map.ReverseConvert(location);
                }

                for (int n = 0; n < seeds.Length / 2; n += 2)
                {
                    long start = long.Parse(seeds[n]);
                    long length = long.Parse(seeds[n + 1]);

                    if (location >= start && location <= start + length - 1)
                    {
                        finished = true;
                        break;
                    }
                }
            }

            

            return i.ToString();
        }

        protected override string GetFolderName()
        {
            return "Day05";
        }
    }
}
