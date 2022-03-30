using Reportity.Abstractions;
using Reportity.Core;
using Reportity.Exception;
using System.Text;

namespace Reportity.Common
{
    internal class CSVRenderer : Renderer, IExporter
    {
        public string ExportToString()
        {
            return Convert.ToBase64String(RenderData());
        }

        public byte[] ExportToStream()
        {
            return RenderData();
        }

        public override byte[] RenderData()
        {
            using (MemoryStream reportData = new MemoryStream())
            {
                try
                {
                    
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
