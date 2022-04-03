using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reportity;
using Reportity.Enums;
using System;
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
            list.Add(new TestData() { testvalue1 = 1, testvalue2 = 2 });
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

        [TestMethod]
        public void TestEntitiyToPDFString()
        {
            List<Customer> list = new List<Customer>();
            list.Add(new Customer() { CustomerName = "Ahmet Necati", OrderDate = new DateTime(2021, 5, 3, 7, 0, 0), Price = 10, ProductType = "Fýrýndan", Quantity = 2 });
            list.Add(new Customer() { CustomerName = "Faruk Biçmez", OrderDate = new DateTime(2021, 5, 3, 4, 12, 0), Price = 5, ProductType = "Klasik", Quantity = 1 });
            list.Add(new Customer() { CustomerName = "Selin Durak", OrderDate = new DateTime(2021, 5, 3, 1, 53, 0), Price = 15, ProductType = "Baharat", Quantity = 3 });
            list.Add(new Customer() { CustomerName = "Hatice Arslan", OrderDate = new DateTime(2021, 5, 3, 22, 9, 0), Price = 20, ProductType = "Fýrýndan", Quantity = 4 });
            list.Add(new Customer() { CustomerName = "Hatice Arslan", OrderDate = new DateTime(2021, 5, 3, 22, 9, 0), Price = 20, ProductType = "Fýrýndan", Quantity = 4 });
            list.Add(new Customer() { CustomerName = "Hatice Arslan", OrderDate = new DateTime(2021, 5, 3, 22, 9, 0), Price = 20, ProductType = "Fýrýndan", Quantity = 4 });
            list.Add(new Customer() { CustomerName = "Hatice Arslan", OrderDate = new DateTime(2021, 5, 3, 22, 9, 0), Price = 20, ProductType = "Fýrýndan", Quantity = 4 });
            list.Add(new Customer() { CustomerName = "Hatice Arslan", OrderDate = new DateTime(2021, 5, 3, 22, 9, 0), Price = 20, ProductType = "Fýrýndan", Quantity = 4 });
            list.Add(new Customer() { CustomerName = "Hatice Arslan", OrderDate = new DateTime(2021, 5, 3, 22, 9, 0), Price = 20, ProductType = "Fýrýndan", Quantity = 4 });
            list.Add(new Customer() { CustomerName = "Hatice Arslan", OrderDate = new DateTime(2021, 5, 3, 22, 9, 0), Price = 20, ProductType = "Fýrýndan", Quantity = 4 });
            list.Add(new Customer() { CustomerName = "Hatice Arslan", OrderDate = new DateTime(2021, 5, 3, 22, 9, 0), Price = 20, ProductType = "Fýrýndan", Quantity = 4 });
            list.Add(new Customer() { CustomerName = "Hatice Arslan", OrderDate = new DateTime(2021, 5, 3, 22, 9, 0), Price = 20, ProductType = "Fýrýndan", Quantity = 4 });
            list.Add(new Customer() { CustomerName = "Hatice Arslan", OrderDate = new DateTime(2021, 5, 3, 22, 9, 0), Price = 20, ProductType = "Fýrýndan", Quantity = 4 });
            list.Add(new Customer() { CustomerName = "Hatice Arslan", OrderDate = new DateTime(2021, 5, 3, 22, 9, 0), Price = 20, ProductType = "Fýrýndan", Quantity = 4 });
            list.Add(new Customer() { CustomerName = "Hatice Arslan", OrderDate = new DateTime(2021, 5, 3, 22, 9, 0), Price = 20, ProductType = "Fýrýndan", Quantity = 4 });
            list.Add(new Customer() { CustomerName = "Hatice Arslan", OrderDate = new DateTime(2021, 5, 3, 22, 9, 0), Price = 20, ProductType = "Fýrýndan", Quantity = 4 });
            list.Add(new Customer() { CustomerName = "Hatice Arslan", OrderDate = new DateTime(2021, 5, 3, 22, 9, 0), Price = 20, ProductType = "Fýrýndan", Quantity = 4 });
            list.Add(new Customer() { CustomerName = "Hatice Arslan", OrderDate = new DateTime(2021, 5, 3, 22, 9, 0), Price = 20, ProductType = "Fýrýndan", Quantity = 4 });
            list.Add(new Customer() { CustomerName = "Hatice Arslan", OrderDate = new DateTime(2021, 5, 3, 22, 9, 0), Price = 20, ProductType = "Fýrýndan", Quantity = 4 });
            list.Add(new Customer() { CustomerName = "Hatice Arslan", OrderDate = new DateTime(2021, 5, 3, 22, 9, 0), Price = 20, ProductType = "Fýrýndan", Quantity = 4 });
            list.Add(new Customer() { CustomerName = "Hatice Arslan", OrderDate = new DateTime(2021, 5, 3, 22, 9, 0), Price = 20, ProductType = "Fýrýndan", Quantity = 4 });
            list.Add(new Customer() { CustomerName = "Hatice Arslan", OrderDate = new DateTime(2021, 5, 3, 22, 9, 0), Price = 20, ProductType = "Fýrýndan", Quantity = 4 });
            list.Add(new Customer() { CustomerName = "Hatice Arslan", OrderDate = new DateTime(2021, 5, 3, 22, 9, 0), Price = 20, ProductType = "Fýrýndan", Quantity = 4 });
            list.Add(new Customer() { CustomerName = "Hatice Arslan", OrderDate = new DateTime(2021, 5, 3, 22, 9, 0), Price = 20, ProductType = "Fýrýndan", Quantity = 4 });
            list.Add(new Customer() { CustomerName = "Hatice Arslan", OrderDate = new DateTime(2021, 5, 3, 22, 9, 0), Price = 20, ProductType = "Fýrýndan", Quantity = 4 });
            list.Add(new Customer() { CustomerName = "Hatice Arslan", OrderDate = new DateTime(2021, 5, 3, 22, 9, 0), Price = 20, ProductType = "Fýrýndan", Quantity = 4 });
            list.Add(new Customer() { CustomerName = "Hatice Arslan", OrderDate = new DateTime(2021, 5, 3, 22, 9, 0), Price = 20, ProductType = "Fýrýndan", Quantity = 4 });
            list.Add(new Customer() { CustomerName = "Hatice Arslan", OrderDate = new DateTime(2021, 5, 3, 22, 9, 0), Price = 20, ProductType = "Fýrýndan", Quantity = 4 });
            list.Add(new Customer() { CustomerName = "Hatice Arslan", OrderDate = new DateTime(2021, 5, 3, 22, 9, 0), Price = 20, ProductType = "Fýrýndan", Quantity = 4 });
            list.Add(new Customer() { CustomerName = "Hatice Arslan", OrderDate = new DateTime(2021, 5, 3, 22, 9, 0), Price = 20, ProductType = "Fýrýndan", Quantity = 4 });
            list.Add(new Customer() { CustomerName = "Hatice Arslan", OrderDate = new DateTime(2021, 5, 3, 22, 9, 0), Price = 20, ProductType = "Fýrýndan", Quantity = 4 });
            list.Add(new Customer() { CustomerName = "Hatice Arslan", OrderDate = new DateTime(2021, 5, 3, 22, 9, 0), Price = 20, ProductType = "Fýrýndan", Quantity = 4 });
            list.Add(new Customer() { CustomerName = "Hatice Arslan", OrderDate = new DateTime(2021, 5, 3, 22, 9, 0), Price = 20, ProductType = "Fýrýndan", Quantity = 4 });
            list.Add(new Customer() { CustomerName = "Hatice Arslan", OrderDate = new DateTime(2021, 5, 3, 22, 9, 0), Price = 20, ProductType = "Fýrýndan", Quantity = 4 });
            string vs = list.ToStringReport(ReportTypes.PdfReport);
        }

        [TestMethod]    
        public void TestEntitiyToPDFStream()
        {
            List<Customer> list = new List<Customer>();
            list.Add(new Customer() { CustomerName = "Ahmet Necati", OrderDate = new DateTime(2021, 5, 3, 7, 0, 0), Price = 10, ProductType = "Fýrýndan" });
            list.Add(new Customer() { CustomerName = "Faruk Biçmez", OrderDate = new DateTime(2021, 5, 3, 4, 12, 0), Price = 5, ProductType = "Klasik", Quantity = 1 });
            list.Add(new Customer() { CustomerName = "Selin Durak", OrderDate = new DateTime(2021, 5, 3, 1, 53, 0), Price = 15, ProductType = "Baharat", Quantity = 3 });
            list.Add(new Customer() { CustomerName = "Hatice Arslan", OrderDate = new DateTime(2021, 5, 3, 22, 9, 0), Price = 20, ProductType = "Fýrýndan", Quantity = 4 });
            byte[] vs = list.ToStreamReport(ReportTypes.PdfReport);
        }
    }
}