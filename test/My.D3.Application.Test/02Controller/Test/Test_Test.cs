using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using My.D3.Application.PublicService.AppServices.Enum;
using My.D3.Web;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace My.D3.Application.Test
{
    public class Test_Test
    {
        public HttpClient Client { get; }
        public Test_Test()
        {
            var bulid = WebHost.CreateDefaultBuilder()..UseStartup<Startup>();
            var server = new TestServer(bulid);
            Client = server.CreateClient();
        }

        /// <summary>
        /// 测试
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        [Fact]
        public async Task Test()
        {


            EnumInDto inDto = new EnumInDto()
            {
                EnumTypeName = "SexTypeEnum",
                Module = "Demo"
            };
            string json = JsonConvert.SerializeObject(inDto);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            //var Client.PostAsync();
            HttpResponseMessage result = await Client.PostAsync("/api/PublicService/GetEnumArray", content);
            string aa = "222";
        }

        [Fact]
        public void Connect_Redis_Test()
        {
            Assert.NotNull("");
        }
    }

}
