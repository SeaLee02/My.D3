using My.D3.Application.PublicService.AppServices.Enum;
using My.D3.DataAccess.Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1 : IClassFixture<TestServerFixture>
    {
        private readonly TestServerFixture _fixture;

        public UnitTest1(TestServerFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Test1()
        {

            EnumInDto inDto = new EnumInDto()
            {
                EnumTypeName = "SexTypeEnum",
                Module = "Demo"
            };
            string json = JsonConvert.SerializeObject(inDto);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage result = await _fixture.Client.PostAsync("/api/PublicService/GetEnumArray", content);
            string bb = await result.Content.ReadAsStringAsync();
            string asd = "";
        }




        [Fact]
        public async Task Test2()
        {
            HttpResponseMessage result = await _fixture.Client.GetAsync("/api/test/Test");
            string bb = await result.Content.ReadAsStringAsync();
            string aa = "";
        }
    }
}
