namespace Reportity.Attributes
{
    public class ReportityHeaderAttribute : Attribute
    {
        public string LogoPath { get; set; }
        public string ReportHeader { get; set; }

        public string? SummaryField { get; set; }

        public ReportityHeaderAttribute(string reportHeader, string logopath)
        {
            ReportHeader = reportHeader;
            LogoPath = logopath;
        }
    }
}
