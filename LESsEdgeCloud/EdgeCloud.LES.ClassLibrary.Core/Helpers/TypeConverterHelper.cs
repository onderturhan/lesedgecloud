using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeCloud.LES.ClassLibrary.Core.Helpers
{
    public static class TypeConverterHelper
    {
        public const string DateFormat = "yyyyMMdd";
        public const string DateTimeFormat = "yyyyMMdd_HHmmss";
        public const string DateTimeOffsetFormat = "yyyyMMdd_HHmmsszzz";

        public static string DateOffsetNowToString => DateTimeOffset.Now.ToString(DateTimeOffsetFormat).Replace("+", "").Replace(":", "");

        public static string DateOffsetToString(this DateTimeOffset date)
        {
            return date.ToString(DateTimeOffsetFormat).Replace("+", "").Replace(":", "");
        }
    }
}
