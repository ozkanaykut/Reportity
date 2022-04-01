using Reportity.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportitiyTest
{
    [ReportityHeaderAttribute(LogoPath = "D:\\logo.png", ReportHeader = "Lays Satış Raporu")]
    public class Customer
    {
        [ReportityColumnName(ColumnName = "Müşteri")]
        public string CustomerName { get; set; }
        [ReportityColumnName(ColumnName = "Ürün Tipi")]
        public string ProductType { get; set; }
        [ReportityColumnName(ColumnName = "Adet")]
        public int Quantity { get; set; }
        [ReportityColumnName(ColumnName = "Fiyat")]
        public decimal Price { get; set; }
        [ReportityColumnName(ColumnName = "Sipariş Tarihi")]
        public DateTime OrderDate { get; set; }
        [ReportityColumnName(ColumnName = "Bug")]
        public TestData bug { get; set; }
    }
}
