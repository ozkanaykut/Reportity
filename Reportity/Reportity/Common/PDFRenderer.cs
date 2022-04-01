using iTextSharp.text;
using iTextSharp.text.pdf;
using Reportity.Abstractions;
using Reportity.Attributes;
using Reportity.Core;
using Reportity.Exception;
using Reportity.Helper;
using System.Collections;
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
                    string reportheader = "";
                    string logopath = "";
                    string? summaryfield = "";
                    short summaryindex = 0;
                    ArrayList cells = new ArrayList();
                    Type type = typeof(T);
                    object[] attrs = type.GetCustomAttributes(true);
                    foreach (object attr in attrs)
                    {
                        ReportityHeaderAttribute? reportityAttr = attr as ReportityHeaderAttribute;
                        if (reportityAttr != null)
                        {
                            reportheader = reportityAttr.ReportHeader;
                            logopath = reportityAttr.LogoPath;
                            summaryfield = reportityAttr.SummaryField;
                        }
                    }

                    foreach (PropertyInfo propertyInfo in type.GetProperties())
                    {
                        object[] colattrs = propertyInfo.GetCustomAttributes(true);
                        foreach (object colattr in colattrs)
                        {
                            ReportityColumnName? columnNameAttr = colattr as ReportityColumnName;
                            if (columnNameAttr != null)
                            {
                                if (TypeChecker.CheckType(propertyInfo))
                                {
                                    if (columnNameAttr.ColumnName != "")
                                        cells.Add(columnNameAttr.ColumnName);
                                    else
                                        cells.Add(propertyInfo.Name);
                                }
                            }
                        }
                    }

                    PdfPTable? table = null;
                    int colCount = cells.Count;
                    table = new PdfPTable(colCount);
                    table.HorizontalAlignment = 1;
                    table.WidthPercentage = 100;

                    BaseFont bf = BaseFont.CreateFont(
                                                    BaseFont.HELVETICA,
                                                    "CP1254",
                                                    BaseFont.NOT_EMBEDDED,
                                                    false);

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
                        iTextSharp.text.Font font = new iTextSharp.text.Font(bf, fontvalue, iTextSharp.text.Font.NORMAL, BaseColor.White);
                        cell = new PdfPCell(new Phrase(item.ToString()?.Replace("<br />", Environment.NewLine), font));

                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell.FixedHeight = 55f;

                        cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#a52a2a"));

                        table.AddCell(cell);
                    }
                    bool color = false;

                    foreach (T data in list)
                    {
                        foreach (PropertyInfo propertyInfo in data.GetType().GetProperties())
                        {
                            if (TypeChecker.CheckType(propertyInfo))
                            {
                                cellText = propertyInfo.GetValue(data).ToString() ?? "";

                                iTextSharp.text.Font font = new iTextSharp.text.Font(bf, fontvalue, iTextSharp.text.Font.NORMAL, BaseColor.Black);
                                cell = new PdfPCell(new Phrase(cellText.Replace("<br />", Environment.NewLine), font));

                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                                cell.MinimumHeight = 35f;
                                cell.BackgroundColor = new BaseColor(color ? Color.LightGray : Color.AliceBlue);

                                table.AddCell(cell);
                            }
                        }
                        color = !color;
                    }

                    Document pdfDoc = new Document(PageSize.A4);
                    if (cells.Count > 7)
                        pdfDoc = new Document(PageSize.A4.Rotate());

                    PdfWriter.GetInstance(pdfDoc, ReportData);
                    pdfDoc.Open();
                    table.HeaderRows = 1;
                   
                    iTextSharp.text.Font fheader = new iTextSharp.text.Font(bf, 15, iTextSharp.text.Font.BOLD, BaseColor.Black);
                    iTextSharp.text.Font fdate = new iTextSharp.text.Font(bf, 11, iTextSharp.text.Font.ITALIC, BaseColor.Black);

                    pdfDoc.Add(new Paragraph(DateTime.Now.ToString(), fdate) { Alignment = Element.ALIGN_RIGHT });
                    pdfDoc.Add(new Paragraph(reportheader, fheader) { Alignment = Element.ALIGN_CENTER });

                    if (logopath != "")
                    {
                        try
                        {
                            System.Drawing.Image imagefromfile = System.Drawing.Image.FromFile(logopath);
                            string[] extensionList = logopath.Split(".");
                            string extension = extensionList.Last().ToUpper();

                            iTextSharp.text.Image? image = null;

                            switch (extension)
                            {
                                case "PNG":
                                    image = iTextSharp.text.Image.GetInstance(imagefromfile, ImageFormat.Png);
                                    break;
                                case "JPG":
                                    image = iTextSharp.text.Image.GetInstance(imagefromfile, ImageFormat.Jpeg);
                                    break;
                            }

                            image?.SetDpi(100, 100);
                            image?.SetAbsolutePosition(20, pdfDoc.Top - 40);
                            image?.ScaleToFit(100, 100);

                            pdfDoc.Add(image);
                        }
                        catch (System.Exception ex)
                        {
                            throw new ReportitiyException(ex.Message);
                        }
                    }

                    pdfDoc.Add(new Paragraph(" "));
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
