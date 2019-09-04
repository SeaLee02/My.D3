namespace My.D3.Areas.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;


    /// <summary>
    /// admin
    /// </summary>
    [Area("Admin")]
    public class MyTemplateController : Controller
    {
        /// <summary>
        /// [xx]主页
        /// </summary>
        /// <returns>页面</returns>
        public IActionResult MyTemplateIndex()
        {
            return base.View();
        }

        /// <summary>
        /// [xx]创建页
        /// </summary>
        /// <returns>页面对象</returns>
        public IActionResult MyTemplateCreate()
        {
            return base.View();
        }

        /// <summary>
        /// [xx]编辑页
        /// </summary>
        /// <returns>页面对象</returns>
        public IActionResult MyTemplateEdit()
        {
            return base.View();
        }

        /// <summary>
        /// [xx]详情页
        /// </summary>
        /// <returns>页面对象</returns>
        public IActionResult MyTemplateDetail()
        {
            return base.View();
        }
    }
}