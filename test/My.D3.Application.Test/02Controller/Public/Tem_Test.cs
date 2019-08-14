//using Moq;
//using My.D3.Application.PublicService.AppServices.Enum;
//using My.D3.Areas.Api.Controllers;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace My.D3.Application.Test
//{
//    public class Tem_Test
//    {
//        private readonly Mock<IEnumAppService> mockBlogSev = new Mock<IEnumAppService>();

//        private readonly PublicServiceController _publicServiceController;
//        public Tem_Test()
//        {
//            //mockBlogSev.Setup(); 
//            _publicServiceController = new PublicServiceController(mockBlogSev.Object);
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
//            var list = await this._publicServiceController.GetEnumArray(inDto);

//            string a = "";
//        }
//    }
//}