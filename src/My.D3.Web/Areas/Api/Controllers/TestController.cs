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

namespace My.D3.Areas.Api.Controllers
{
    [MyVersion("T1")]
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IMyDemoStudentAppService _myDemoStudentAppService;
        private readonly MyDbContext _db;

        public TestController(IMyDemoStudentAppService myDemoStudentAppService, MyDbContext db)
        {
            _db = db;
            this._myDemoStudentAppService = myDemoStudentAppService;
        }


        [Authorize(Roles = "admin")]
        [HttpGet("Test")]
        public async Task<IActionResult> Test()
        {
            List<DemoStudentEntity> AA = await _db.DemoStudent.AsNoTracking().ToListAsync();
            DbSet<DemoStudentEntity> dd = _db.Set<DemoStudentEntity>();

            var list = await this._myDemoStudentAppService.GetAllListDto();
            string aa = "";
            return await Task.FromResult(Ok(list));
        }
    }
}