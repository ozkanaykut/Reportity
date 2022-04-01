using Newtonsoft.Json;
using Reportity.Abstractions;
using Reportity.Core;
using Reportity.Exception;
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
                    string value = JsonConvert.SerializeObject(list);
                    XmlDocument? doc = JsonConvert.DeserializeXmlNode("{\"Row\":" + value + "}", "Reportity");
                    if (doc!= null)
                    {
                        doc.Save(ReportData);
                        ReportData.Flush();
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
