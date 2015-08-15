using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vemcode.Dsv
{
    public interface IConverter<T>
    {
        T Convert(string[] data);
    }
}
