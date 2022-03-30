using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reportity;
using Reportity.Enums;
using System.Collections.Generic;

namespace ReportitiyTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<TestData> list = new List<TestData>();
            list.Add(new TestData() { testvalue1 = 1, testvalue2 = 2 } );
            byte[] vs = list.ToStreamReport(ReportTypes.PdfReport);
        }
    }
}