using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode23.Day07
{
    internal class Hand(string cards, int bid) : IComparable<Hand>
    {
        public string Cards { get; set; } = cards;
        public int Bid { get; set; } = bid;

        public int CompareTo(Hand? other)
        {
            if(Type() != other.Type()) return Type() - other.Type();

            return Value() - other.Value();
        }

        public virtual int Type()
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

            if (occurences.Count == 1) return 6; // Five of a kind

            if (occurences.Count == 2)
            {
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
                foreach (int i in occurences.Values)
                {
                    if (i == 2)
                    {
                        return 2; // Two pairs
                    }
                }

                return 3; // Three of a kind
            }


            if (occurences.Count == 4) return 1; // One pair

            return 0; // High card
        }

        public int Value()
        {
            int returnvalue = 0;

            foreach (char c in Cards)
            {
                returnvalue *= 15;
                returnvalue += CardValue(c);
            }

            return returnvalue;
        }

        public virtual int CardValue(char character)
        {
            switch (character)
            {
                case 'A': return 14;
                case 'K': return 13;
                case 'Q': return 12;
                case 'J': return 11;
                case 'T': return 10;
                case '9': return 9;
                case '8': return 8;
                case '7': return 7;
                case '6': return 6;
                case '5': return 5;
                case '4': return 4;
                case '3': return 3;
                case '2': return 2;
                default: return -1;
            }
        }
    }
}
