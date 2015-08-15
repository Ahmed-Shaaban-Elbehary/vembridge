using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vemcode.Dsv
{
    /// <summary>
    /// Converter for converting from string array to a typed object
    /// </summary>
    /// <typeparam name="T">Type of object</typeparam>
    public interface IConverter<T>
    {
        /// <summary>
        /// Converts a string array to typed object
        /// </summary>
        /// <param name="data">String array input</param>
        /// <returns>Converted typed object</returns>
        T Convert(string[] data);
    }
}
