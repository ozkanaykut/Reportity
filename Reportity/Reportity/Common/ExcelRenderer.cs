using Reportity.Abstractions;
using Reportity.Core;

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
            throw new NotImplementedException();
        }
    }
}
