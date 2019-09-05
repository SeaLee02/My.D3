using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace My.D3.Application.PublicService.AppServices.Grid
{
    /// <summary>
    /// Grid接收参数
    /// </summary>
    public class GetGridListInDto
    {
        /// <summary>
        /// 视图的名称
        /// </summary>
        [Required]
        public string ViewName { get; set; }

        /// <summary>
        /// 排序字段 
        /// </summary>
        public string Sort { get; set; }

        /// <summary>
        /// 排序（asc 和 desc）
        /// </summary>
        public string Order { get; set; }

        /// <summary>
        /// 过滤字符串
        /// </summary>
        public string Filter { get; set; }

        /// <summary>
        /// 第几页
        /// </summary>
        public int page { get; set; }


        /// <summary>
        /// 每页多少行
        /// </summary>
        public int limit { get; set; }

        /// <summary>
        /// 查询的列
        /// </summary>
        public string Select { get; set; }

        /// <summary>
        /// autoMapper需要使用的
        /// </summary>
        public IConfigurationProvider configurationProvider { get; set; }

    }
}
