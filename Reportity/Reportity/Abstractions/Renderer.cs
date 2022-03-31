namespace Reportity.Abstractions
{
    public abstract class Renderer<T>
    {
        public abstract byte[] RenderData(IEnumerable<T> list);
    }
}
