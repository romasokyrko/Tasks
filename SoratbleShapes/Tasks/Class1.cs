using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;

    public class RailFenceCipher

    {
        private int _rails;

        public RailFenceCipher(int rails)
        {
            _rails = rails;
        }

        public string Encode(string input)
        {
            return input
                .Select((c, i) => (c, r: GetRow(i)))
                .GroupBy(v => v.r)
                .SelectMany(v => v)
                .Aggregate(new StringBuilder(),
                    (sb, v) => sb.Append(v.c),
                    sb => sb.ToString());
        }

        private int GetRow(int i) => Math.Abs((_rails - 1) - Math.Abs(Math.Abs(i % (2 * (_rails - 1))) - (_rails - 1)));

        public string Decode(string input)
        {
            return Enumerable.Range(0, input.Length)
                .GroupBy(GetRow)
                .SelectMany(i => i)
                .Zip(input, (f, s) => (i: f, c: s))
                .OrderBy(v => v.i)
                .Aggregate(new StringBuilder(),
                    (sb, v) => sb.Append(v.c),
                    sb => sb.ToString());
        }
    }
   
}

