namespace Reportity.Core
{
    internal interface IByteExporter<T>
    {
        byte[] ExportToStream(IEnumerable<T> list);
    }
}
