using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vemcode.Dsv
{
    /// <summary>
    /// Reader for delimiter-separated values (DSV) files
    /// </summary>
    /// <typeparam name="T">Typed object which can be deserialized from DSV record</typeparam>
    public class DsvReader<T> where T : class
    {
        /// <summary>
        /// Constructs DSV reader
        /// </summary>
        /// <param name="reader">Text reader</param>
        /// <param name="delimiter">Delimiter text</param>
        /// <param name="converter">Converter from delimited record to typed object</param>
        public DsvReader(TextReader reader, string delimiter, IConverter<T> converter)
        {
            this.Reader = reader;
            this.Delimiter = delimiter;
            this.Converter = converter;
        }

        /// <summary>
        /// Represents the underlying text reader used for reading delimiter-separated values
        /// </summary>
        public TextReader Reader { get; private set; }

        /// <summary>
        /// Represents the delimiter text for separating fields on a single line
        /// </summary>
        public string Delimiter { get; private set; }

        /// <summary>
        /// Represents converter for converting from delimited string record to typed object
        /// </summary>
        public IConverter<T> Converter { get; private set; }

        /// <summary>
        /// Reads a single typed object from a DSV source
        /// </summary>
        /// <returns>Typed object</returns>
        public T Read()
        {
            string line = Reader.ReadLine();

            if (line == null)
            {
                return null;
            }

            string[] parts = line.Split(new[] { Delimiter }, StringSplitOptions.None);

            return Converter.Convert(parts);
        }

        /// <summary>
        /// Reads all the typed objects from a DSV source
        /// </summary>
        /// <returns>List of typed objects</returns>
        public List<T> ReadToEnd()
        {
            List<T> records = new List<T>();

            T record = null;

            while ((record = Read()) != null)
            {
                records.Add(record);
            }

            return records;
        }
    }
}
