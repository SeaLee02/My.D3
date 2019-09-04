namespace My.D3.Areas.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// 学院表
    /// </summary>
    [Area("Demo")]
    public class DemoSchoolController : Controller
    {
        /// <summary>
        /// [学院表]主页
        /// </summary>
        /// <returns>页面</returns>
        public IActionResult DemoSchoolIndex()
        {
            return base.View();
        }

        /// <summary>
        /// [学院表]创建页
        /// </summary>
        /// <returns>页面对象</returns>
        public IActionResult DemoSchoolCreate()
        {
            return base.View();
        }

        /// <summary>
        /// [学院表]编辑页
        /// </summary>
        /// <returns>页面对象</returns>
        public IActionResult DemoSchoolEdit()
        {
            return base.View();
        }

        /// <summary>
        /// [学院表]详情页
        /// </summary>
        /// <returns>页面对象</returns>
        public IActionResult DemoSchoolDetail()
        {
            return base.View();
        }
    }
}
