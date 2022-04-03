namespace Reportity.Helper
{
    internal class TypeChecker
    {
        private static readonly HashSet<Type> NumericTypes = new HashSet<Type>
    {
        typeof(int),  typeof(double),  typeof(decimal),
        typeof(long), typeof(short),   
        typeof(ulong),   typeof(ushort),
        typeof(uint), typeof(float)
    };
        private static readonly HashSet<Type> AvailableType = new HashSet<Type>
    {
        typeof(int),  typeof(double),  typeof(decimal), typeof(string),
        typeof(long), typeof(short), typeof(bool), 
        typeof(ulong),   typeof(ushort),typeof(char),
        typeof(uint), typeof(float), typeof(DateTime)
    };
        public static bool CheckType(Type source)
        {
           return AvailableType.Contains(Nullable.GetUnderlyingType(source) ?? source);
        }

        public static bool isNumeric(Type source)
        {
            return NumericTypes.Contains(Nullable.GetUnderlyingType(source) ?? source);
        }
    }
}
