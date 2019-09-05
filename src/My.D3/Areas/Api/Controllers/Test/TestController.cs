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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using AutoMapper;

namespace My.D3.Areas.Api.Controllers
{
    [MyVersion("T1")]
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IDemoStudentAppService _demoStudentAppService;
        private readonly MyDbContext _db;
        private readonly IMapper _mapper;

        public TestController(IDemoStudentAppService demoStudentAppService, MyDbContext db)
        {
            this._demoStudentAppService = demoStudentAppService;
            this._db = db;
        }

        /// <summary>
        /// 测试授权
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("Login")]
        public async Task<string> Login()
        {
            try
            {
                var now = DateTime.UtcNow;
                var issuer = "issuer";
                var audience = "audience";

                ClaimsIdentity identity = new ClaimsIdentity(JwtBearerDefaults.AuthenticationScheme);
                List<Claim> claims = identity.Claims.ToList();
                claims.AddRange(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub,"sealee"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.Now.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
                });

                // var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, "sealee"));
                claims.Add(new Claim(ClaimTypes.Role, "admin"));

                //ClaimsIdentity identity = new ClaimsIdentity(JwtBearerDefaults.AuthenticationScheme);
                //identity.AddClaim(new Claim(ClaimTypes.Name, "admin"));
                //identity.AddClaim(new Claim("Role", "admin"));
                var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("sdfsdfsrty45634kkhllghtdgdfss345t678fs"));
                var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
                var jwt = new JwtSecurityToken(
                   issuer: issuer,
                   audience: audience,
                   claims: claims,
                   notBefore: now,
                   expires: DateTime.Now.Add(TimeSpan.FromHours(1)),
                   signingCredentials: signingCredentials
               );
                // 生成 Token
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
                return await Task.FromResult(encodedJwt);
            }
            catch (Exception ex)
            {

                return await Task.FromResult(ex.Message);
            }
        }

        /// <summary>
        /// 测试
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpGet("Test")]
        public async Task<IActionResult> Test()
        {
            DemoStudentEntity demoStudentEntity = new DemoStudentEntity();
            demoStudentEntity.StuName = "ppp";
            demoStudentEntity.IsDeleted = 0;
            _db.DemoStudent.Add(demoStudentEntity);
            await _db.SaveChangesAsync();
            var list = await this._demoStudentAppService.GetAllListDto();
            return await Task.FromResult(Ok(list));
        }

        /// <summary>
        /// 测试
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("Test3")]
        public async Task<IActionResult> Test3()
        {
            var list = await this._demoStudentAppService.GetAllListDto();
            return await Task.FromResult(Ok(list));
        }
        /// <summary>
        /// 测试
        /// </summary>
        /// <returns></returns>
        [HttpGet("Test4")]
        public async Task<IActionResult> Test4()
        {
            var list = await this._demoStudentAppService.GetAllListDto();
            return await Task.FromResult(Ok(list));
        }


    }
}