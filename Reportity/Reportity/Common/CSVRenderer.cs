using Reportity.Abstractions;
using Reportity.Core;
using Reportity.Exception;
using Reportity.Helper;
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
                    Type type = typeof(T);
                    StringBuilder builder = new StringBuilder();
                    List<string> header = new List<string>();
                    foreach (PropertyInfo propertyInfo in type.GetProperties())
                    {
                        if (TypeChecker.CheckType(propertyInfo))
                        {
                            header.Add(propertyInfo.Name.ToUpper());
                        }
                    }

                    builder.Append(string.Join(",", header) + Environment.NewLine);

                    foreach (var data in list)
                    {
                        List<string> values = new List<string>();
                        foreach (PropertyInfo propertyInfo in data.GetType().GetProperties())
                        {
                            if (TypeChecker.CheckType(propertyInfo))
                            {
                                values.Add(propertyInfo.GetValue(data).ToString());
                            }
                        }
                        builder.Append(string.Join(",", values) + Environment.NewLine);
                    }
                    
                    TextWriter tw = new StreamWriter(reportData);
                    tw.Write(builder.ToString());
                    tw.Flush();
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
