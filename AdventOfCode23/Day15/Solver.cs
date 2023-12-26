using AdventOfCode23.Day11;
using System.Diagnostics;

namespace AdventOfCode23.Day15
{
    internal class Solver : AdventSolver
    {
        public override string GetPuzzleOutput1()
        {
            long sum = 0;

            foreach(string s in puzzleInput[0].Split(","))
            {
                sum += Hash(s);
            }

            return sum.ToString();
        }

        public override string GetPuzzleOutput2()
        {
            List<Lens>[] lenses = new List<Lens>[256];
            for(int i = 0; i < lenses.Length; i++)
            {
                lenses[i] = new();
            }

            foreach(string command in puzzleInput[0].Split(","))
            {
                if (command.Contains("=")) // Add new lens
                {
                    string[] args = command.Split("=");

                    List<Lens> lensList = lenses[Hash(args[0])];

                    int position = lensList.Count;

                    for(int i = 0; i < lensList.Count; i++)
                    {
                        if (lensList[i].Label.Equals(args[0]))
                        {
                            position = i;
                            lensList.RemoveAt(i);
                            break;
                        }
                    }

                    lensList.Insert(position, new Lens(args[0], int.Parse(args[1])));
                }
                else // Remove lens
                {
                    string label = command.Split("-")[0];

                    List<Lens> lensList = lenses[Hash(label)];

                    for (int i = 0; i < lensList.Count; i++)
                    {
                        if (lensList[i].Label.Equals(label))
                        {
                            lensList.RemoveAt(i);
                            break;
                        }
                    }
                }
            }

            long sum = 0;

            for(int i = 0; i < lenses.Length; i++)
            {
                sum += FocusPower(lenses[i]) * (i + 1);
            }

            return sum.ToString();
        }

        private long FocusPower(List<Lens> lenses)
        {
            long sum = 0;

            for(int i = 0; i < lenses.Count; i++)
            {
                sum += lenses[i].Focus * (i + 1);
            }

            return sum;
        }

        private int Hash(string str)
        {
            int hash = 0;

            foreach(char c in str)
            {
                hash += (int)c;
                hash *= 17;
                hash %= 256;
            }


            return hash;
        }

        protected override string GetFolderName()
        {
            return "Day15";
        }
    }
}
