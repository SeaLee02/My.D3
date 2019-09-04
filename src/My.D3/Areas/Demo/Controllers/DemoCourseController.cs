namespace My.D3.Areas.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// 课程表
    /// </summary>
    [Area("Demo")]
    public class DemoCourseController : Controller
    {
        /// <summary>
        /// [课程表]主页
        /// </summary>
        /// <returns>页面</returns>
        public IActionResult DemoCourseIndex()
        {
            return base.View();
        }

        /// <summary>
        /// [课程表]创建页
        /// </summary>
        /// <returns>页面对象</returns>
        public IActionResult DemoCourseCreate()
        {
            return base.View();
        }

        /// <summary>
        /// [课程表]编辑页
        /// </summary>
        /// <returns>页面对象</returns>
        public IActionResult DemoCourseEdit()
        {
            return base.View();
        }

        /// <summary>
        /// [课程表]详情页
        /// </summary>
        /// <returns>页面对象</returns>
        public IActionResult DemoCourseDetail()
        {
            return base.View();
        }
    }
}
