using Reportity.Enums;

namespace Reportity
{
    public static class Reportity
    {
        public static byte[] ToStreamReport<T>(this IEnumerable<T> list, ReportTypes type)
        {
            return null;
        }

        public static byte[] ToStringReport<T>(this IEnumerable<T> list, ReportTypes type)
        {
            return null;
        }
    }
}
