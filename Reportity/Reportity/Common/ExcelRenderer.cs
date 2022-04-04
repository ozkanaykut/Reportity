using OfficeOpenXml;
using OfficeOpenXml.Style;
using Reportity.Abstractions;
using Reportity.Core;
using Reportity.Exception;
using Reportity.Helper;
using Reportity.Utils;
using System.Drawing;
using System.Reflection;

namespace Reportity.Common
{
    internal class ExcelRenderer<T> : Renderer<T>, IStringExporter<T>, IByteExporter<T>
    {
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
            MemoryStream? Reportdata = null;
            using (var package = new ExcelPackage())
            {
                try
                {
                    using (ReportityReportObject ReportObject = new ReportityReportObject(typeof(T)))
                    {
                        ReportObject.setHeaders();
                        ReportObject.setAttributes();

                        if (ReportObject.Cells.Count < 1)
                            throw new ReportitiyException("No column to be processed, Make sure you add column attribute.");

                        int row = 1;
                        var worksheet = package.Workbook.Worksheets.Add(ReportObject.ReportHeader);
                        worksheet.Row(1).Height = 20;
                        worksheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        worksheet.Row(1).Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        worksheet.Row(1).Style.Font.Bold = true;

                        for (int i = 0; i < ReportObject.Cells.Count; i++)
                        {
                            worksheet.Cells[1, i + 1].Value = ReportObject.Cells[i].ToString();
                            worksheet.Cells[1, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(Color.Wheat);
                            worksheet.Cells[1, i + 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                            worksheet.Cells[1, i + 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            worksheet.Cells[1, i + 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                            worksheet.Cells[1, i + 1].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        }

                        int recordIndex = 2;
                        bool color = false;

                        foreach (T data in list)
                        {
                            List<string> values = new List<string>();
                            foreach (PropertyInfo propertyInfo in data.GetType().GetProperties())
                            {
                                if (TypeChecker.CheckType(propertyInfo.PropertyType))
                                {
                                    worksheet.Cells[recordIndex, row].Value = propertyInfo.GetValue(data)?.ToString();
                                    worksheet.Cells[recordIndex, row].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                                    worksheet.Cells[recordIndex, row].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                    worksheet.Cells[recordIndex, row].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    worksheet.Cells[recordIndex, row].Style.Fill.BackgroundColor.SetColor(color ? Color.LightGray : Color.AliceBlue);
                                    worksheet.Cells[recordIndex, row].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                    worksheet.Cells[recordIndex, row].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                    worksheet.Cells[recordIndex, row].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                    worksheet.Cells[recordIndex, row].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                    row++;
                                }
                            }
                            recordIndex++;
                            row = 1;
                            color = !color;
                        }

                        for (int i = 0; i < ReportObject.Cells.Count; i++)
                            worksheet.Column(i + 1).AutoFit();
                        Reportdata = new MemoryStream(package.GetAsByteArray());
                    }
                }
                catch (System.Exception ex)
                {
                    throw new ReportitiyException(ex.Message);
                }
            }
            return Reportdata.ToArray();
        }
    }
}
