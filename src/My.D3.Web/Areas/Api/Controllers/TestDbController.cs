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

namespace My.D3.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestDbController : ControllerBase
    {
        private readonly IDemoStudentAppService _demoStudentAppService;
        private readonly MyDbContext _db;

        public TestDbController(IDemoStudentAppService demoStudentAppService, MyDbContext db)
        {
            _db = db;
            this._demoStudentAppService = demoStudentAppService;
        }

        [HttpGet("Test")]
        public async Task<IActionResult> Test()
        {

            DbSet<DemoStudentEntity> dd = _db.Set<DemoStudentEntity>();

            var list = await this._demoStudentAppService.GetAllListDto();
            string aa = "";
            return await Task.FromResult(Ok(list));
        }
    }
}