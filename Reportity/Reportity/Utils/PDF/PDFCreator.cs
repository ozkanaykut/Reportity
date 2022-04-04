using iTextSharp.text;
using iTextSharp.text.pdf;
using Reportity.Exception;
using Reportity.Helper;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;

namespace Reportity.Utils.PDF
{
    internal partial class PDFCreator
    {
        public void setColumnSettings(int ColumnSize)
        {
            if (ColumnSize < 1)
                throw new ReportitiyException("No column to be processed, Make sure you add column attribute.");
            ColumnCount = ColumnSize;
            ColumnsWidth = new int[ColumnSize];
        }
        public void setFontSettings()
        {
            ReportBaseFont = BaseFont.CreateFont(
                                                        BaseFont.HELVETICA,
                                                        "CP1254",
                                                        BaseFont.NOT_EMBEDDED,
                                                        false);
            FontSize = (Ceiling - ColumnCount) / 2;
            if (FontSize < 6)
                FontSize = 6;
            else if (FontSize > 15)
                FontSize = 15;
        }
        public void setTableSettings()
        {
            ReportTable = new PdfPTable(ColumnCount);
            ReportTable.HorizontalAlignment = HorizontalAlignment;
            ReportTable.WidthPercentage = WidthPercentage;
        }
        public void setHeaderValues(ArrayList Cells)
        {
            foreach (var item in Cells)
            {
                iTextSharp.text.Font font = new iTextSharp.text.Font(ReportBaseFont, FontSize, iTextSharp.text.Font.NORMAL, BaseColor.White);
                ReportCell = new PdfPCell(new Phrase(item.ToString()?.Replace("<br />", Environment.NewLine), font));

                ReportCell.HorizontalAlignment = Element.ALIGN_CENTER;
                ReportCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                ReportCell.FixedHeight = 55f;

                ReportCell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#a52a2a"));

                ReportTable.AddCell(ReportCell);
            }
        }
        public void setReportValues<T>(IEnumerable<T> List, ReportityReportObject ReportObject)
        {
            foreach (var data in List)
            {
                foreach (PropertyInfo propertyInfo in data.GetType().GetProperties())
                {
                    if (TypeChecker.CheckType(propertyInfo.PropertyType))
                    {
                        ReportObject.takeSummaryObjects(propertyInfo, data);

                        ReportCellText = propertyInfo.GetValue(data)?.ToString();

                        iTextSharp.text.Font font = new iTextSharp.text.Font(ReportBaseFont, FontSize, iTextSharp.text.Font.NORMAL, BaseColor.Black);
                        ReportCell = new PdfPCell(new Phrase(ReportCellText?.Replace("<br />", Environment.NewLine), font));

                        ReportCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        ReportCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        ReportCell.MinimumHeight = 35f;
                        ReportCell.BackgroundColor = new BaseColor(SwitchColor ? Color.LightGray : Color.AliceBlue);

                        ReportTable.AddCell(ReportCell);
                    }
                }
                SwitchColor = !SwitchColor;
            }
        }
        public void setReportSummaryItem(decimal? SummaryTotal, string SummaryName)
        {
            iTextSharp.text.Font fontsummary = new iTextSharp.text.Font(ReportBaseFont, FontSize, iTextSharp.text.Font.BOLDITALIC, BaseColor.Black);

            for (int i = 0; i < ColumnCount - 2; i++)
            {
                ReportCell = new PdfPCell(new Phrase(""));
                ReportCell.BackgroundColor = new BaseColor(Color.Gray);
                ReportTable.AddCell(ReportCell);
            }

            ReportCell = new PdfPCell(new Phrase(("Toplam " + SummaryName).Replace("<br />", Environment.NewLine), fontsummary));

            ReportCell.HorizontalAlignment = Element.ALIGN_CENTER;
            ReportCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            ReportCell.MinimumHeight = 35f;
            ReportCell.BackgroundColor = new BaseColor(Color.Gray);

            ReportTable.AddCell(ReportCell);

            ReportCell = new PdfPCell(new Phrase(SummaryTotal.ToString()?.Replace("<br />", Environment.NewLine), fontsummary));

            ReportCell.HorizontalAlignment = Element.ALIGN_CENTER;
            ReportCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            ReportCell.MinimumHeight = 35f;
            ReportCell.BackgroundColor = new BaseColor(Color.Gray);

            ReportTable.AddCell(ReportCell);
        }
        public void setPDFDocument(int ColumnSize)
        {
            if (ColumnSize > 7)
                PDFDocument = new Document(PageSize.A4.Rotate());
        }
        public void setReportImage(string LogoPath)
        {
            if (LogoPath != "")
            {
                try
                {
                    System.Drawing.Image imagefromfile = System.Drawing.Image.FromFile(LogoPath);
                    string[] extensionList = LogoPath.Split(".");
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

                    image?.SetDpi(ImageDpiSettings, ImageDpiSettings);
                    image?.SetAbsolutePosition(PDFDocument.LeftMargin, PDFDocument.Top - PDFDocument.TopMargin);
                    image?.ScaleToFit(ImageDpiSettings, ImageDpiSettings);

                    PDFDocument.Add(image);
                }
                catch (System.Exception ex)
                {
                    throw new ReportitiyException(ex.Message);
                }
            }
        }
    }
}
