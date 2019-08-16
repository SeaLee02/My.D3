using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My.D3.Application.AppServices.Demo;
using My.D3.DataAccess.Framework;
using My.D3.Entity.Demo;
using My.D3.DataAccess;
using Microsoft.AspNetCore.Authorization;
using My.D3.Configurations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace My.D3.Areas.Api.Controllers
{
    [MyVersion("T1")]
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IMyDemoStudentAppService _myDemoStudentAppService;

        public TestController(IMyDemoStudentAppService myDemoStudentAppService, MyDbContext db)
        {
            this._myDemoStudentAppService = myDemoStudentAppService;
        }

        /// <summary>
        /// 测试授权
        /// </summary>
        /// <returns></returns>
        [HttpGet("Login")]
        public async Task Login()
        {
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

            identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));

            var principal = new ClaimsPrincipal(identity);

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal).Wait();
        }

        /// <summary>
        /// 测试
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpGet("Test")]
        public async Task<IActionResult> Test()
        {
            var list = await this._myDemoStudentAppService.GetAllListDto();
            string aa = "";
            return await Task.FromResult(Ok(list));
        }
    }
}