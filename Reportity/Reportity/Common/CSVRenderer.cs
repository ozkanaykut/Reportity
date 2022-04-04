using Reportity.Abstractions;
using Reportity.Core;
using Reportity.Exception;
using Reportity.Helper;
using Reportity.Utils;
using System.Reflection;
using System.Text;

namespace Reportity.Common
{
    internal class CSVRenderer<T> : Renderer<T>, IStringExporter<T>, IByteExporter<T>
    {
        public string ExportToString(IEnumerable<T> list)
        {
            return Convert.ToBase64String(RenderData(list));
        }

        public byte[] ExportToStream(IEnumerable<T> list)
        {
            return RenderData(list);
        }

        public override byte[] RenderData(IEnumerable<T> list)
        {
            using (MemoryStream reportData = new MemoryStream())
            {
                try
                {
                    using (ReportityReportObject ReportObject = new ReportityReportObject(typeof(T)))
                    {
                        ReportObject.setHeaders();
                        ReportObject.setAttributes();

                        if (ReportObject.Cells.Count < 1)
                            throw new ReportitiyException("No column to be processed, Make sure you add column attribute.");

                        StringBuilder builder = new StringBuilder();
                        builder.Append(string.Join(",", ReportObject.Cells.Cast<string>().ToList()) + Environment.NewLine);

                        foreach (T data in list)
                        {
                            List<string> values = new List<string>();
                            foreach (PropertyInfo propertyInfo in data.GetType().GetProperties())
                            {
                                if (TypeChecker.CheckType(propertyInfo.PropertyType))
                                {
                                    values.Add(propertyInfo.GetValue(data)?.ToString());
                                }
                            }
                            builder.Append(string.Join(",", values) + Environment.NewLine);
                        }

                        TextWriter tw = new StreamWriter(reportData);
                        tw.Write(builder.ToString());
                        tw.Flush();
                    }
                }
                catch (System.Exception ex)
                {
                    throw new ReportitiyException(ex.Message);
                }
                return reportData.ToArray();
            }
        }
    }
}
