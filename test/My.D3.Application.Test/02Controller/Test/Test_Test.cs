//using System.Net;
//using System.Net.Http;
//using System.Threading.Tasks;
//using Xunit;
//using Microsoft.AspNetCore.TestHost;
//using Microsoft.AspNetCore.Hosting;
//using My.D3.Web;
//using My.D3.Application.PublicService.AppServices.Enum;
//using Newtonsoft.Json;
//using System.Text;
//using Microsoft.AspNetCore;

//namespace My.D3.Application.Test
//{
//    /// <summary>
//    /// 继承测试  测试控制器
//    /// </summary>
//    public class Test_Test
//    {
//        private readonly HttpClient _client;
//        public Test_Test()
//        {
//            //需要修改连接到数据
//            var server = new TestServer(WebHost.CreateDefaultBuilder().UseContentRoot(@"E:\Code\DotnetCli\DemoD3\My.D3\src\My.D3.Web")
//               .UseEnvironment("Development")
//               .UseStartup<Startup>());
//            _client = server.CreateClient();
//        }

//        /// <summary>
//        /// 测试
//        /// </summary>
//        /// <param name="inDto"></param>
//        /// <returns></returns>
//        [Fact]
//        public async Task Test()
//        {
//            EnumInDto inDto = new EnumInDto()
//            {
//                EnumTypeName = "SexTypeEnum",
//                Module = "Demo"
//            };
//            string json = JsonConvert.SerializeObject(inDto);
//            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
//            HttpResponseMessage result = await _client.PostAsync("/api/PublicService/GetEnumArray", content);
//            string bb = await result.Content.ReadAsStringAsync();

//            string aa = "222";
//        }

//        [Fact]
//        public void Connect_Redis_Test()
//        {
//            Assert.NotNull("");
//        }
//    }

//}
