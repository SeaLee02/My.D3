using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.D3.Util.Extensions
{
    public static class StringEx
    {
        /// <summary>
        /// string转任意类型
        /// </summary>
        /// <typeparam name="T">需要转换的类型</typeparam>
        /// <param name="s"></param>
        /// <returns></returns>
        public static T ConvertTo<T>(this string s)
        {
            if (typeof(T).IsEnum)
            {
                return (T)Enum.Parse(typeof(T), s);
            }
            return (T)Convert.ChangeType(s, typeof(T));
        }

        /// <summary>
        /// 首字母 转大写
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToCamel(this string str)
        {
            string[] array = str.Split(new char[1]
            {
            '_'
            });
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array[i][0].ToString().ToUpper() + array[i].Substring(1, array[i].Length - 1);
            }
            return string.Join("", array);
        }

        /// <summary>
        /// int默认值
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int ToDefault(this string s, int defaultValue)
        {
            if (int.TryParse(s, out int result))
            {
                return result;
            }
            return defaultValue;
        }
    }
}
