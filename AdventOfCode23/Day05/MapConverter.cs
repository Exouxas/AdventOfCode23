using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode23.Day05
{
    internal class MapConverter
    {
        private List<Converter> _converters = new();

        public void Add(string line)
        {
            string[] lineSplit = line.Split(' ');
            long src = long.Parse(lineSplit[1]);
            long dst = long.Parse(lineSplit[0]);
            long len = long.Parse(lineSplit[2]);

            _converters.Add(new Converter(src, dst, len));
        }

        public long Convert(long source)
        {
            Converter conv = null;

            _converters = _converters.OrderBy(x => x.Source).ToList();
            foreach (Converter converter in _converters)
            {
                if (source >= converter.Source)
                {
                    conv = converter;
                }
                else
                {
                    break;
                }
            }

            if (conv == null) return source;

            return conv.Convert(source);
        }

        public long ReverseConvert(long destination)
        {
            Converter conv = null;

            _converters = _converters.OrderBy(x => x.Destination).ToList();
            foreach (Converter converter in _converters)
            {
                if (destination >= converter.Destination)
                {
                    conv = converter;
                }
                else
                {
                    break;
                }
            }

            if (conv == null) return destination;

            return conv.ReverseConvert(destination);
        }
    }
}
