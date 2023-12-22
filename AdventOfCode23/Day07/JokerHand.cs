using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode23.Day07
{
    internal class JokerHand(string cards, int bid) : Hand(cards, bid)
    {
        public override int Type()
        {
            Dictionary<char, int> occurences = new();
            foreach (char c in Cards)
            {
                if (occurences.ContainsKey(c))
                {
                    occurences[c]++;
                }
                else
                {
                    occurences.Add(c, 1);
                }
            }

            int jokers = 0;
            if (occurences.ContainsKey('J')) jokers = occurences['J'];


            if (occurences.Count == 1) return 6; // Five of a kind

            if (occurences.Count == 2)
            {
                if (jokers > 0) return 6; // Fake five of a kind

                int first = occurences.Values.First();
                if (first == 1 || first == 4)
                {
                    return 5; // Four of a kind
                }
                else
                {
                    return 4; // Full house
                }
            }

            if (occurences.Count == 3)
            {
                if (jokers >= 2) return 5; // Fake four of a kind

                foreach (int i in occurences.Values)
                {
                    if (i == 2)
                    {
                        if (jokers == 1) return 4; // Fake full house
                        if (jokers == 2) return 5; // Fake four of a kind
                        return 2; // Two pairs
                    }
                }

                if (jokers >= 1) return 5; // Fake four of a kind
                return 3; // Three of a kind
            }

            if (occurences.Count == 4)
            {
                if (jokers > 0) return 3; // Fake three of a kind
                return 1; // One pair
            }

            if (jokers == 1) return 1; // One pair
            return 0; // High card
        }

        public override int CardValue(char character)
        {
            if (character == 'J') return 1;
            return base.CardValue(character);
        }
    }
}
