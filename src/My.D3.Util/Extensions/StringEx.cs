using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.D3.Util.Extensions
{
    public static class StringEx
    {
        public static T ConvertTo<T>(this string s)
        {
            if (typeof(T).IsEnum)
            {
                return (T)Enum.Parse(typeof(T), s);
            }
            return (T)Convert.ChangeType(s, typeof(T));
        }
    }
}
