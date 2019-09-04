namespace My.D3.Areas.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// 学生课程表
    /// </summary>
    [Area("Demo")]
    public class DemoStudent2CourseController : Controller
    {
        /// <summary>
        /// [学生课程表]主页
        /// </summary>
        /// <returns>页面</returns>
        public IActionResult DemoStudent2CourseIndex()
        {
            return base.View();
        }

        /// <summary>
        /// [学生课程表]创建页
        /// </summary>
        /// <returns>页面对象</returns>
        public IActionResult DemoStudent2CourseCreate()
        {
            return base.View();
        }

        /// <summary>
        /// [学生课程表]编辑页
        /// </summary>
        /// <returns>页面对象</returns>
        public IActionResult DemoStudent2CourseEdit()
        {
            return base.View();
        }

        /// <summary>
        /// [学生课程表]详情页
        /// </summary>
        /// <returns>页面对象</returns>
        public IActionResult DemoStudent2CourseDetail()
        {
            return base.View();
        }
    }
}
