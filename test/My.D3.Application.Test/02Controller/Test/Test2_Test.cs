//using My.D3.Application.PublicService.AppServices.Enum;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace My.D3.Application.Test
//{
//    /// <summary>
//    /// 集成测试 测试appservice层接口
//    /// </summary>
//    public class Test2_Test
//    {

//        private readonly IEnumAppService _enumAppService;

//        public Test2_Test(IEnumAppService enumAppService)
//        {
//            this._enumAppService = enumAppService;
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
//            var list = await _enumAppService.GetEnumArray(inDto);
//            string aa = "222";
//        }

//    }

//}

