using Reportity.Attributes;
using System;

namespace ReportitiyTest
{
    [ReportityHeader("Lays Satış Raporu", "D:\\logo.jpg", SummaryField = "Quantity")]
    public class Customer
    {
        [ReportityColumnName("Müşteri")]
        public string? CustomerName { get; set; }
        [ReportityColumnName("Ürün Tipi")]
        public string? ProductType { get; set; }
        [ReportityColumnName("Adet")]
        public float? Quantity { get; set; }
        [ReportityColumnName("Fiyat")]
        public decimal? Price { get; set; }
        [ReportityColumnName("Sipariş Tarihi")]
        public DateTime OrderDate { get; set; }
        [ReportityColumnName("Bug")]
        public TestData? bug { get; set; }
    }
}
