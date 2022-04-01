namespace Reportity.Abstractions
{
    internal abstract class Renderer<T>
    {
        public abstract byte[] RenderData(IEnumerable<T> list);
    }
}
