using Reportity.Common;
using Reportity.Core;
using Reportity.Enums;

namespace Reportity
{
    public static class Reportity
    {
        public static byte[] ToStreamReport<T>(this IEnumerable<T> list, ReportTypes type)
        {
            return null;
        }

        public static string ToStringReport<T>(this IEnumerable<T> list, ReportTypes type)
        {
            string result = "";
            switch (type)
            {
                case ReportTypes.XmlReport:
                    IStringExporter<T> Xmlrenderer = new XmlRenderer<T>();
                    result = Xmlrenderer.ExportToString(list);
                    break;
                case ReportTypes.CsvReport:
                    IStringExporter<T> Csvrenderer = new CSVRenderer<T>();
                    result = Csvrenderer.ExportToString(list);
                    break;
                case ReportTypes.ExcelReport:
                    IStringExporter<T> Excelrenderer = new ExcelRenderer<T>();
                    result = Excelrenderer.ExportToString(list);
                    break;
                case ReportTypes.PdfReport:
                    IStringExporter<T> PDFrenderer = new PDFRenderer<T>();
                    result = PDFrenderer.ExportToString(list);
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
