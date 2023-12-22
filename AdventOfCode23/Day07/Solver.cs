using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace AdventOfCode23.Day07
{
    internal class Solver : AdventSolver
    {
        public override string GetPuzzleOutput1()
        {
            List<Hand> hands = new();

            foreach(string line in puzzleInput)
            {
                string[] linePart = line.Split(' ');
                string hand = linePart[0];
                int bid = int.Parse(linePart[1]);

                hands.Add(new Hand(hand, bid));
            }

            hands.Sort();

            int i = 0;
            int sum = 0;
            foreach(Hand hand in hands)
            {
                i++;
                sum += hand.Bid * i;
            }

            return sum.ToString();
        }

        public override string GetPuzzleOutput2()
        {
            List<JokerHand> hands = new();

            foreach (string line in puzzleInput)
            {
                string[] linePart = line.Split(' ');
                string hand = linePart[0];
                int bid = int.Parse(linePart[1]);

                hands.Add(new JokerHand(hand, bid));
            }

            hands.Sort();

            int i = 0;
            int sum = 0;
            foreach (JokerHand hand in hands)
            {
                i++;
                sum += hand.Bid * i;
            }

            return sum.ToString();
        }



        protected override string GetFolderName()
        {
            return "Day07";
        }
    }
}
