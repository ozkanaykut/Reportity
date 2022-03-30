using Reportity.Abstractions;
using Reportity.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reportity.Common
{
    internal class PDFRenderer : Renderer, IExporter
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
