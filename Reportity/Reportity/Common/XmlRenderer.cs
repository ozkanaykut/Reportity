using Newtonsoft.Json;
using Reportity.Abstractions;
using Reportity.Core;
using Reportity.Exception;
using Reportity.Helper;
using Reportity.Utils;
using System.Dynamic;
using System.Reflection;
using System.Xml;

namespace Reportity.Common
{
    internal class XmlRenderer<T> : Renderer<T>, IStringExporter<T>, IByteExporter<T>
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
            using (MemoryStream ReportData = new MemoryStream())
            {
                try
                {
                    using (ReportityReportObject ReportObject = new ReportityReportObject(typeof(T)))
                    {
                        ReportObject.setHeaders();
                        ReportObject.setAttributes();

                        if (ReportObject.Cells.Count < 1)
                            throw new ReportitiyException("No column to be processed, Make sure you add column attribute.");
                        List<Dictionary<string, object>> NewValues = new List<Dictionary<string, object>>();
                        foreach (var data in list)
                        {
                            Dictionary<string, object> Values = new Dictionary<string, object>();
                            foreach (PropertyInfo propertyInfo in data.GetType().GetProperties())
                            {
                                if (TypeChecker.CheckType(propertyInfo.PropertyType))
                                {
                                    Values.Add((ReportObject.ColumnNameMap[propertyInfo.Name] == "" ? propertyInfo.Name : ReportObject.ColumnNameMap[propertyInfo.Name]).Replace(" ", ""), propertyInfo.GetValue(data)?.ToString());
                                }
                            }
                            NewValues.Add(Values);
                        }

                        string JsonValue = JsonConvert.SerializeObject(NewValues);
                        XmlDocument? doc = JsonConvert.DeserializeXmlNode("{\"Row\":" + JsonValue + "}", ReportObject.ReportHeader?.Replace(" ", ""));
                        if (doc != null)
                        {
                            doc.Save(ReportData);
                            ReportData.Flush();
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
