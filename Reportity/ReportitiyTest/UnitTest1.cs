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
            string vs = testobject().ToStringReport(ReportTypes.CsvReport);
        }

        [TestMethod]
        public void TestEntitiyToCSVStream()
        {
            byte[] vs = testobject().ToStreamReport(ReportTypes.CsvReport);
        }

        [TestMethod]
        public void TestEntitiyToExcelString()
        {
            string vs = testobject().ToStringReport(ReportTypes.ExcelReport);
        }

        [TestMethod]
        public void TestEntitiyToExcelStream()
        {
            byte[] vs = testobject().ToStreamReport(ReportTypes.ExcelReport);
        }

        [TestMethod]
        public void TestEntitiyToXMLString()
        {
            string vs = testobject().ToStringReport(ReportTypes.XmlReport);
        }

        [TestMethod]
        public void TestEntitiyToXMLStream()
        {
            byte[] vs = testobject().ToStreamReport(ReportTypes.XmlReport);
        }

        [TestMethod]
        public void TestEntitiyToPDFString()
        {
            string vs = testobject().ToStringReport(ReportTypes.PdfReport);
        }

        [TestMethod]    
        public void TestEntitiyToPDFStream()
        {
            byte[] vs = testobject().ToStreamReport(ReportTypes.PdfReport);
        }

        public List<Customer> testobject()
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
            return list;
        }
    }
}