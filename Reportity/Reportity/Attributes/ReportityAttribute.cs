using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reportity.Attributes
{
    public class ReportityHeaderAttribute : Attribute
    {
        public string LogoPath { get; set; }
        public string ReportHeader { get; set; }
    }
}
