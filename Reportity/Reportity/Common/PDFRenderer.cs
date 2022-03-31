using iTextSharp.text;
using iTextSharp.text.pdf;
using Reportity.Abstractions;
using Reportity.Core;
using Reportity.Exception;
using System.Collections;
using System.Drawing;
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
                    ArrayList cells = new ArrayList();
                    Type type = typeof(T);
                    foreach (PropertyInfo propertyInfo in type.GetProperties())
                    {
                        cells.Add(propertyInfo.Name.ToUpper());
                    }

                    PdfPTable table = null;

                    int colCount = cells.Count;
                    table = new PdfPTable(colCount);
                    table.HorizontalAlignment = 1;
                    table.WidthPercentage = 100;

                    int[] colWidths = new int[colCount];

                    PdfPCell cell;
                    string cellText;

                    float fontvalue = (ceiling - colCount) / 2;
                    if (fontvalue < 6)
                        fontvalue = 6;
                    else if (fontvalue > 15)
                        fontvalue = 15;
                    foreach (var item in cells)
                    {
                        cellText = item.ToString();

                        BaseFont bf = BaseFont.CreateFont(
                                                BaseFont.HELVETICA,
                                                BaseFont.CP1252,
                                                BaseFont.EMBEDDED,
                                                false);

                        iTextSharp.text.Font font = new iTextSharp.text.Font(bf, fontvalue, iTextSharp.text.Font.BOLD, BaseColor.White);
                        cell = new PdfPCell(new Phrase(cellText.Replace("<br />", Environment.NewLine), font));

                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell.FixedHeight = 55f;

                        cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#a52a2a"));

                        table.AddCell(cell);
                    }
                    bool color = false;

                    foreach (var data in list)
                    {
                        foreach (PropertyInfo propertyInfo in data.GetType().GetProperties())
                        {
                            cellText = propertyInfo.GetValue(data).ToString();
                            BaseFont bf = BaseFont.CreateFont(
                                                    BaseFont.HELVETICA,
                                                    BaseFont.CP1252,
                                                    BaseFont.EMBEDDED,
                                                    false);

                            iTextSharp.text.Font font = new iTextSharp.text.Font(bf, fontvalue, iTextSharp.text.Font.NORMAL, BaseColor.Black);
                            cell = new PdfPCell(new Phrase(cellText.Replace("<br />", Environment.NewLine), font));

                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cell.MinimumHeight = 35f;
                            cell.BackgroundColor = new BaseColor(color ? Color.LightGray : Color.AliceBlue);

                            table.AddCell(cell);
                        }
                        color = !color;
                    }

                    Document pdfDoc = new Document(PageSize.A4);
                    if (cells.Count > 7)
                        pdfDoc = new Document(PageSize.A4.Rotate());

                    PdfWriter.GetInstance(pdfDoc, ReportData);
                    pdfDoc.Open();
                    table.HeaderRows = 1;

                    iTextSharp.text.Font fdefault = FontFactory.GetFont("Verdana", 15, iTextSharp.text.Font.BOLD, BaseColor.Blue);

                    pdfDoc.Add(new Paragraph(" ", fdefault));
                    pdfDoc.Add(new Paragraph("Header", fdefault) { Alignment = Element.ALIGN_CENTER });
                    pdfDoc.Add(new Paragraph(" ", fdefault));
                    pdfDoc.Add(table);

                    pdfDoc.Close();
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
