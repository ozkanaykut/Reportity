using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reportity.Attributes
{
    public class ReportityColumnName : Attribute
    {
        public string ColumnName { get; set; }
    }
}
