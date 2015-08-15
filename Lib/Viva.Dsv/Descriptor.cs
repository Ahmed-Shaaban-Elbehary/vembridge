using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viva.Dsv
{
    public class Descriptor
    {
        public Descriptor(string delimiter, string[] nullSymbols)
        {
            this.Delimiter = delimiter;
            this.NullSymbols = nullSymbols;
        }

        public string Delimiter { get; private set; }

        public string[] NullSymbols { get; private set; }
    }
}
