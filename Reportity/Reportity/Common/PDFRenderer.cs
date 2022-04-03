using iTextSharp.text;
using iTextSharp.text.pdf;
using Reportity.Abstractions;
using Reportity.Core;
using Reportity.Exception;
using Reportity.Helper;
using Reportity.Utils;
using Reportity.Utils.PDF;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;

namespace Reportity.Common
{
    internal class PDFRenderer<T> : Renderer<T>, IStringExporter<T>, IByteExporter<T>
    {
        const int ceiling = 25;
        public byte[] ExportToStream(IEnumerable<T> list)
        {
            return RenderData(list);
        }

        public string ExportToString(IEnumerable<T> list)
        {
            return Convert.ToBase64String(RenderData(list));
        }

        public override byte[] RenderData(IEnumerable<T> list)
        {
            using (MemoryStream ReportData = new MemoryStream())
            {
                try
                {
                    using (ReportityReportObject ReportObject = new ReportityReportObject(typeof(T)))
                    {
                        ReportObject.setHeaders();
                        ReportObject.setAttributes();

                        using (PDFCreator creator = new PDFCreator())
                        {
                            creator.setColumnSettings(ReportObject.Cells.Count);
                            creator.setTableSettings();
                            creator.setFontSettings();
                            creator.setHeaderValues(ReportObject.Cells);
                            creator.setReportValues(list, ReportObject);
                            if (ReportObject.SummaryType != null)
                                creator.setReportSummaryItem(ReportObject.SummaryValues.Sum(), ReportObject.SummaryName);

                            creator.setPDFDocument(ReportObject.Cells.Count);

                            PdfWriter.GetInstance(creator.PDFDocument, ReportData);
                            creator.PDFDocument.Open();
                            creator.ReportTable.HeaderRows = 1;

                            iTextSharp.text.Font fheader = new iTextSharp.text.Font(creator.ReportBaseFont, 15, iTextSharp.text.Font.BOLD, BaseColor.Black);
                            iTextSharp.text.Font fdate = new iTextSharp.text.Font(creator.ReportBaseFont, 11, iTextSharp.text.Font.ITALIC, BaseColor.Black);

                            creator.PDFDocument.Add(new Paragraph(DateTime.Now.ToString(), fdate) { Alignment = Element.ALIGN_RIGHT });
                            creator.PDFDocument.Add(new Paragraph(ReportObject.ReportHeader, fheader) { Alignment = Element.ALIGN_CENTER });
                            creator.setReportImage(ReportObject.LogoPath);
                            creator.PDFDocument.Add(new Paragraph(" "));
                            creator.PDFDocument.Add(creator.ReportTable);
                            creator.PDFDocument.Close();
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    throw new ReportitiyException(ex.Message);
                }
                return ReportData.ToArray();
            }
        }
    }
}
