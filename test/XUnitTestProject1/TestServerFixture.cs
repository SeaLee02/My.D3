using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using My.D3.DataAccess.Framework;
using My.D3.Entity.Demo;
using My.D3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace XUnitTestProject1
{
    public class TestServerFixture : IDisposable
    {
        private readonly TestServer _testServer;
        public HttpClient Client { get; }

        public TestServerFixture()
        {
            var bulild = new WebHostBuilder().UseStartup<Startup1>();
            _testServer = new TestServer(bulild);
            Client = _testServer.CreateClient();
            string Authorization = Token();
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Authorization);

        }

        private string Token()
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
            return encodedJwt;
        }


        public void Dispose()
        {
            Client.Dispose();
            _testServer.Dispose();
        }
    }
}
