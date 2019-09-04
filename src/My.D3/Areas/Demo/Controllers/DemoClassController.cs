namespace My.D3.Areas.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// 班级表
    /// </summary>
    [Area("Demo")]
    public class DemoClassController : Controller
    {
        /// <summary>
        /// [班级表]主页
        /// </summary>
        /// <returns>页面</returns>
        public IActionResult DemoClassIndex()
        {
            return base.View();
        }

        /// <summary>
        /// [班级表]创建页
        /// </summary>
        /// <returns>页面对象</returns>
        public IActionResult DemoClassCreate()
        {
            return base.View();
        }

        /// <summary>
        /// [班级表]编辑页
        /// </summary>
        /// <returns>页面对象</returns>
        public IActionResult DemoClassEdit()
        {
            return base.View();
        }

        /// <summary>
        /// [班级表]详情页
        /// </summary>
        /// <returns>页面对象</returns>
        public IActionResult DemoClassDetail()
        {
            return base.View();
        }
    }
}
