using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reportity.Exception
{
    internal class ReportitiyException : System.Exception
    {
        public ReportitiyException(string ex) : base(ex)
        {

        }
    }
}
