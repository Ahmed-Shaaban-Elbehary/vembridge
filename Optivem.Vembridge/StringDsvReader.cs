using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vemcode.Dsv
{
    /// <summary>
    /// Untyped reader for DSV files
    /// </summary>
    public class StringDsvReader : DsvReader<string[]>
    {
        private static IConverter<string[]> converter = new StringConverter();

        /// <summary>
        /// Constructs the DSV reader
        /// </summary>
        /// <param name="reader">Text reader for DSV source</param>
        /// <param name="delimiter">Delimiter for DSV records</param>
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
