using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reportity.Abstractions
{
    public abstract class Renderer<T>
    {
        public abstract byte[] RenderData(IEnumerable<T> list);
    }
}
