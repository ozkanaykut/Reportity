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
        public void TestEntitiyToCSVString()
        {
            List<TestData> list = new List<TestData>();
            list.Add(new TestData() { testvalue1 = 1, testvalue2 = 2 } );
            list.Add(new TestData() { testvalue1 = 3, testvalue2 = 4 });
            string vs = list.ToStringReport(ReportTypes.CsvReport);
        }

        [TestMethod]
        public void TestEntitiyToCSVStream()
        {
            List<TestData> list = new List<TestData>();
            list.Add(new TestData() { testvalue1 = 1, testvalue2 = 2 });
            list.Add(new TestData() { testvalue1 = 3, testvalue2 = 4 });
            byte[] vs = list.ToStreamReport(ReportTypes.CsvReport);
        }

        [TestMethod]
        public void TestEntitiyToExcelString()
        {
            List<TestData> list = new List<TestData>();
            list.Add(new TestData() { testvalue1 = 1, testvalue2 = 2 });
            list.Add(new TestData() { testvalue1 = 3, testvalue2 = 4 });
            string vs = list.ToStringReport(ReportTypes.ExcelReport);
        }

        [TestMethod]
        public void TestEntitiyToExcelStream()
        {
            List<TestData> list = new List<TestData>();
            list.Add(new TestData() { testvalue1 = 1, testvalue2 = 2 });
            list.Add(new TestData() { testvalue1 = 3, testvalue2 = 4 });
            byte[] vs = list.ToStreamReport(ReportTypes.ExcelReport);
        }

        [TestMethod]
        public void TestEntitiyToXMLString()
        {
            List<TestData> list = new List<TestData>();
            list.Add(new TestData() { testvalue1 = 1, testvalue2 = 2 });
            list.Add(new TestData() { testvalue1 = 3, testvalue2 = 4 });
            string vs = list.ToStringReport(ReportTypes.XmlReport);
        }

        [TestMethod]
        public void TestEntitiyToXMLStream()
        {
            List<TestData> list = new List<TestData>();
            list.Add(new TestData() { testvalue1 = 1, testvalue2 = 2 });
            list.Add(new TestData() { testvalue1 = 3, testvalue2 = 4 });
            byte[] vs = list.ToStreamReport(ReportTypes.XmlReport);
        }
    }
}