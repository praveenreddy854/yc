using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YC.Utils
{
    public static class YCParser
    {
        public static decimal? ToDecimal(string val)
        {
            if (val == string.Empty)
            {
                return null;
            }
            return Decimal.Parse(val);
        }

        public static int? ToInt(string val)
        {
            if (val == string.Empty)
            {
                return null;
            }
            return int.Parse(val);
        }
    }
}