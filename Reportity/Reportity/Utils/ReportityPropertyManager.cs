using Reportity.Attributes;
using Reportity.Helper;
using System.Reflection;

namespace Reportity.Utils
{
    internal partial class ReportityReportObject
    {
        public void setHeaders()
        {
            object[] attrs = EntityType.GetCustomAttributes(true);
            foreach (object attr in attrs)
            {
                ReportityHeaderAttribute? ReportityAttr = attr as ReportityHeaderAttribute;
                if (ReportityAttr != null)
                {
                    ReportHeader = ReportityAttr.ReportHeader;
                    LogoPath = ReportityAttr.LogoPath;
                    SummaryField = ReportityAttr.SummaryField;
                }
            }
        }

        public void setAttributes()
        {
            foreach (PropertyInfo PropertyInfo in EntityType.GetProperties())
            {
                object[] colattrs = PropertyInfo.GetCustomAttributes(true);
                foreach (object colattr in colattrs)
                {
                    ReportityColumnName? columnNameAttr = colattr as ReportityColumnName;
                    if (columnNameAttr != null)
                    {
                        if (TypeChecker.CheckType(PropertyInfo.PropertyType))
                        {
                            string Name = columnNameAttr.ColumnName == "" ? PropertyInfo.Name : columnNameAttr.ColumnName;
                            Cells.Add(Name);

                            if (SummaryField == PropertyInfo.Name)
                            {
                                if (TypeChecker.isNumeric(PropertyInfo.PropertyType))
                                {
                                    SummaryType = PropertyInfo.GetType();
                                    SummaryName = Name;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void takeSummaryObjects<T>(PropertyInfo propertyInfo, T data)
        {
            if (propertyInfo.Name == SummaryField)
            {
                if (TypeChecker.isNumeric(propertyInfo.PropertyType))
                    SummaryValues.Add(decimal.Parse(propertyInfo.GetValue(data) == null ? "0" : propertyInfo.GetValue(data).ToString()));
            }
        }
    }
}
