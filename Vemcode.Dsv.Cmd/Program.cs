using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vemcode.Dsv.Cmd
{
    /// <summary>
    /// Main execution class for command line program
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main entry point for command line program
        /// </summary>
        /// <param name="args">Command line arguments</param>
        static void Main(string[] args)
        {
            if(args.Length < 2)
            {
                System.Console.Error.WriteLine("Must supply arguments delimiter and at least one file: <delimiter> <filepath1> <filepath2> <filepath3> ...");
            }

            string delimiter = args[0];

            for (int i = 1; i < args.Length; i++)
            {
                string path = args[i];

                if(!File.Exists(path))
                {
                    System.Console.Error.WriteLine("File does not exist: " + path);
                    continue;
                }

                Read(delimiter, path);
            }
        }

        private static void Read(string delimiter, string path)
        {
            using(TextReader textReader = new StreamReader(path))
            {
                StringDsvReader dsvReader = new StringDsvReader(textReader, delimiter);

                string[] record = null;

                while((record = dsvReader.Read()) != null)
                {
                    System.Console.WriteLine(string.Join(delimiter, record));
                }
            }
        }
    }
}
