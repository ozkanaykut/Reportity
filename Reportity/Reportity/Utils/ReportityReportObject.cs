using System.Collections;

namespace Reportity.Utils
{
    internal partial class ReportityReportObject : IDisposable
    {
        public string? ReportHeader { get; set; }
        public string? LogoPath { get; set; }
        public string? SummaryField { get; set; }
        public string? SummaryName { get; set; }
        public ArrayList Cells { get; set; } = new ArrayList();
        public Type? EntityType { get; set; }
        public Type? SummaryType { get; set; }
        public List<decimal?> SummaryValues { get; set; } = new List<decimal?>();


        public ReportityReportObject(Type _entityType)
        {
            EntityType = _entityType;
        }

        public void Dispose()
        {
            ReportHeader = null;
            LogoPath = null;
            SummaryField = null;
            SummaryName = null;
            Cells.Clear();
            EntityType = null;
            SummaryType = null;
            SummaryValues.Clear();
        }
    }
}
