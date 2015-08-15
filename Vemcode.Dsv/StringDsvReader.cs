using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vemcode.Dsv
{
    public class StringDsvReader : DsvReader<string[]>
    {
        private static IConverter<string[]> converter = new StringConverter();

        public StringDsvReader(TextReader reader, string delimiter)
            : base(reader, delimiter, converter) { }

        private class StringConverter : IConverter<string[]>
        {
            public string[] Convert(string[] data)
            {
                // No conversion, simply relay the received data
                return data;
            }
        }
    }
}
