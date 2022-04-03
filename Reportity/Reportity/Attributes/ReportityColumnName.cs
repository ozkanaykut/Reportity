namespace Reportity.Attributes
{
    public class ReportityColumnName : Attribute
    {
        public string ColumnName { get; set; }

        public ReportityColumnName(string columnName)
        {
            ColumnName = columnName;
        }
    }
}
