using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.D3.Configurations
{
    /// <summary>
    /// DateTime2string
    /// </summary>
    public class DateTimeTypeConverter : ITypeConverter<DateTime, string>
    {
        public string Convert(DateTime source, string destination, ResolutionContext context)
        {
            return source.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}