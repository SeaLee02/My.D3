namespace My.D3.Areas.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// 学生表
    /// </summary>
    [Area("Demo")]
    public class DemoStudentController : Controller
    {
        /// <summary>
        /// [学生表]主页
        /// </summary>
        /// <returns>页面</returns>
        public IActionResult DemoStudentIndex()
        {
            return base.View();
        }

        /// <summary>
        /// [学生表]创建页
        /// </summary>
        /// <returns>页面对象</returns>
        public IActionResult DemoStudentCreate()
        {
            return base.View();
        }

        /// <summary>
        /// [学生表]编辑页
        /// </summary>
        /// <returns>页面对象</returns>
        public IActionResult DemoStudentEdit()
        {
            return base.View();
        }

        /// <summary>
        /// [学生表]详情页
        /// </summary>
        /// <returns>页面对象</returns>
        public IActionResult DemoStudentDetail()
        {
            return base.View();
        }
    }
}
