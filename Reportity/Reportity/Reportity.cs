using Reportity.Common;
using Reportity.Core;
using Reportity.Enums;
using Reportity.Exception;

namespace Reportity
{
    public static class Reportity
    {
        public static byte[] ToStreamReport<T>(this IEnumerable<T> list, ReportTypes type)
        {
            IByteExporter<T> Renderer = null;
            switch (type)
            {
                case ReportTypes.XmlReport:
                    Renderer = new XmlRenderer<T>();
                    break;
                case ReportTypes.CsvReport:
                    Renderer = new CSVRenderer<T>();
                    break;
                case ReportTypes.ExcelReport:
                    Renderer = new ExcelRenderer<T>();
                    break;
                case ReportTypes.PdfReport:
                    Renderer = new PDFRenderer<T>();
                    break;
                default:
                    break;
            }
            if (Renderer != null)
                return Renderer.ExportToStream(list);
            else
                throw new ReportitiyException("Not implemented report type.");
        }

        public static string ToStringReport<T>(this IEnumerable<T> list, ReportTypes type)
        {
            IStringExporter<T> Renderer = null;
            switch (type)
            {
                case ReportTypes.XmlReport:
                    Renderer = new XmlRenderer<T>();
                    break;
                case ReportTypes.CsvReport:
                    Renderer = new CSVRenderer<T>();
                    break;
                case ReportTypes.ExcelReport:
                    Renderer = new ExcelRenderer<T>();
                    break;
                case ReportTypes.PdfReport:
                    Renderer = new PDFRenderer<T>();
                    break;
                default:
                    break;
            }
            if (Renderer != null)
                return Renderer.ExportToString(list);
            else
                throw new ReportitiyException("Not implemented report type.");
        }
    }
}
