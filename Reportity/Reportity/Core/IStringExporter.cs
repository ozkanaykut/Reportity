using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reportity.Core
{
    internal interface IStringExporter<T>
    {
        string ExportToString(IEnumerable<T> list);
    }
}
