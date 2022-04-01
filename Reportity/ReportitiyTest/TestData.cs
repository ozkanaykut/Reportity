using Reportity.Attributes;
using System;
using System.Drawing.Imaging;

namespace ReportitiyTest
{
    [ReportityHeaderAttribute("Deneme Raporu", "D:\\logo.png")]
    public class TestData
    {
        public int testvalue1 { get; set; }
        public int testvalue2 { get; set; }
    }
}
