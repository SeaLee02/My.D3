//using Microsoft.AspNetCore;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.TestHost;
//using Moq;
//using My.D3.Application.PublicService.AppServices.Enum;
//using My.D3.Areas.Api.Controllers;
//using My.D3.Web;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace My.D3.Application.Test
//{
//    public class PublicServiceController_Test
//    {
//        public HttpClient Client { get; }

//        public PublicServiceController_Test()
//        {
//            var server = new TestServer(WebHost.CreateDefaultBuilder().UseStartup<Startup>());
//            Client = server.CreateClient();
//        }

//        /// <summary>
//        /// 测试
//        /// </summary>
//        /// <param name="inDto"></param>
//        /// <returns></returns>
//        [Fact]
//        public async Task GetEnumArray_Test()
//        {
//            EnumInDto inDto = new EnumInDto()
//            {
//                EnumTypeName = "SexTypeEnum",
//                Module = "Demo"
//            };
//            string json = JsonConvert.SerializeObject(inDto);
//            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

//            //var Client.PostAsync();
//            HttpResponseMessage result = await Client.PostAsync("/api/PublicService/GetEnumArray", content);

//            string ss = await result.Content.ReadAsStringAsync();

//            string a = "";
//        }
//    }
//}
