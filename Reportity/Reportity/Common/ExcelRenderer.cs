using Reportity.Abstractions;
using Reportity.Core;

namespace Reportity.Common
{
    internal class ExcelRenderer : Renderer, IExporter
    {
        public byte[] ExportToStream()
        {
            return RenderData();
        }

        public string ExportToString()
        {
            return Convert.ToBase64String(RenderData());
        }

        public override byte[] RenderData()
        {
            throw new NotImplementedException();
        }
    }
}
