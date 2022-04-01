using OfficeOpenXml;
using OfficeOpenXml.Style;
using Reportity.Abstractions;
using Reportity.Core;
using Reportity.Exception;
using Reportity.Helper;
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
            MemoryStream Reportdata = null;
            using (var package = new ExcelPackage())
            {
                try
                {
                    int row = 1;
                    Type type = typeof(T);
                    List<string> header = new List<string>();
                    foreach (PropertyInfo propertyInfo in type.GetProperties())
                    {
                        if (TypeChecker.CheckType(propertyInfo))
                        {
                            header.Add(propertyInfo.Name.ToUpper());
                        }
                    }

                    var worksheet = package.Workbook.Worksheets.Add("Reportity");
                    worksheet.Row(1).Height = 20;
                    worksheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Row(1).Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    worksheet.Row(1).Style.Font.Bold = true;


                    for (int i = 0; i < header.Count; i++)
                    {
                        worksheet.Cells[1, i + 1].Value = header[i].ToString();
                        worksheet.Cells[1, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(Color.Wheat);
                        worksheet.Cells[1, i + 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        worksheet.Cells[1, i + 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        worksheet.Cells[1, i + 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        worksheet.Cells[1, i + 1].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    }

                    int recordIndex = 2;
                    bool color = false;

                    foreach (var data in list)
                    {
                        List<string> values = new List<string>();
                        foreach (PropertyInfo propertyInfo in data.GetType().GetProperties())
                        {
                            if (TypeChecker.CheckType(propertyInfo))
                            {
                                worksheet.Cells[recordIndex, row].Value = propertyInfo.GetValue(data).ToString();
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

                    for (int i = 0; i < header.Count; i++)
                        worksheet.Column(i + 1).AutoFit();
                    Reportdata = new MemoryStream(package.GetAsByteArray());
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
