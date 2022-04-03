using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reportity.Utils.PDF
{
    internal partial class PDFCreator : IDisposable
    {
        const int Ceiling = 25;
        public PdfPTable? ReportTable { get; set; }
        public int ColumnCount { get; set; }
        public BaseFont ReportBaseFont { get; set; }
        public int[]? ColumnsWidth { get; set; }
        public PdfPCell? ReportCell { get; set; }
        public string? ReportCellText { get; set; }
        public float FontSize { get; set; }
        public bool SwitchColor { get; set; } = false;
        public int HorizontalAlignment { get; set; } = 1;
        public float WidthPercentage { get; set; } = 100;
        public Document PDFDocument { get; set; } = new Document(PageSize.A4);

        public void Dispose()
        {
            ReportTable = null;
            ColumnCount = 0;
            ReportBaseFont = null;
            ColumnsWidth = null;
            ReportCell = null;
            ReportCellText = null;
            FontSize = 0;
            HorizontalAlignment = 0;
            WidthPercentage = 0;
            PDFDocument = null;
        }
    }
}
