using Reportity.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportitiyTest
{
    [ReportityHeader("Lays Satış Raporu", "D:\\logo.png", SummaryField = "Price")]
    public class Customer
    {
        [ReportityColumnName("Müşteri")]
        public string? CustomerName { get; set; }
        [ReportityColumnName("Ürün Tipi")]
        public string? ProductType { get; set; }
        [ReportityColumnName("Adet")]
        public int? Quantity { get; set; }
        [ReportityColumnName("Fiyat")]
        public decimal? Price { get; set; }
        [ReportityColumnName("Sipariş Tarihi")]
        public DateTime OrderDate { get; set; }
        [ReportityColumnName("Bug")]
        public TestData? bug { get; set; }
    }
}
