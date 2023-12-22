using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode23.Day05
{
    internal class Converter(long source, long destination, long length) : IComparable<Converter>
    {
        public long Source { get; set; } = source;
        public long Destination { get; set; } = destination;
        public long Length { get; set; } = length;

        public int CompareTo(Converter? other)
        {
            if(Source < other.Source) return -1;
            if(Source > other.Source) return 1;
            return 0;
        }

        public long Convert(long src)
        {
            if (src < Source || src > Source + Length - 1)
            {
                return src;
            }

            return src - Source + Destination;
        }

        public long ReverseConvert(long dst)
        {
            if (dst < Destination || dst > Destination + Length - 1)
            {
                return dst;
            }

            return dst + Source - Destination;
        }
    }
}
