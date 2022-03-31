namespace Reportity.Core
{
    internal interface IStringExporter<T>
    {
        string ExportToString(IEnumerable<T> list);
    }
}
