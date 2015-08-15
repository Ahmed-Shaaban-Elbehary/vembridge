using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vemcode.Dsv
{
    /// <summary>
    /// Used for reading delimited text (e.g. comma-delimited, tab-delimited formats)
    /// </summary>
    public class DsvReader<T> where T : class
    {
        public DsvReader(TextReader reader, string delimiter, IConverter<T> converter)
        {
            this.Reader = reader;
            this.Delimiter = delimiter;
            this.Converter = converter;
        }

        public TextReader Reader { get; private set; }

        public string Delimiter { get; private set; }

        public IConverter<T> Converter { get; private set; }

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
