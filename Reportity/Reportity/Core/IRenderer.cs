using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reportity.Core
{
    internal interface IExporter
    {
        string ExportToString();
        byte[] ExportToStream();
    }
}
