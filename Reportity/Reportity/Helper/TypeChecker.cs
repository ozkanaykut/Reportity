using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reportity.Helper
{
    internal class TypeChecker
    {
        readonly private static List<string> types = new List<string>() { "System.String", "System.Boolean", "System.Char", "System.Decimal", "System.Double", "System.Single", "System.Int32", "System.UInt32", "System.Int64", "System.UInt64", "System.Int16", "System.UInt16" };
        public static bool CheckType(PropertyInfo source)
        {
            if (source.PropertyType == typeof(string)
                || source.PropertyType == typeof(int)
                || source.PropertyType == typeof(char)
                || source.PropertyType == typeof(decimal)
                || source.PropertyType == typeof(DateTime)
                || source.PropertyType == typeof(long)
                || source.PropertyType == typeof(float)
                || source.PropertyType == typeof(double)
                || source.PropertyType == typeof(bool)
                || source.PropertyType == typeof(short)
                || source.PropertyType == typeof(int)
                || source.PropertyType == typeof(uint)
                || source.PropertyType == typeof(ulong)
                || source.PropertyType == typeof(ushort)
                || source.PropertyType == typeof(int?)
                || source.PropertyType == typeof(char?)
                || source.PropertyType == typeof(decimal?)
                || source.PropertyType == typeof(DateTime?)
                || source.PropertyType == typeof(long?)
                || source.PropertyType == typeof(float?)
                || source.PropertyType == typeof(double?)
                || source.PropertyType == typeof(bool?)
                || source.PropertyType == typeof(short?)
                || source.PropertyType == typeof(int?)
                || source.PropertyType == typeof(uint?)
                || source.PropertyType == typeof(ulong?)
                || source.PropertyType == typeof(ushort?))
                return true;
            else
                return false;
        }
    }
}
