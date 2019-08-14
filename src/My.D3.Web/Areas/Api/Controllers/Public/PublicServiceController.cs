namespace My.D3.Areas.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using My.D3.Application.PublicService.AppServices.Enum;
    using My.D3.Configurations;

    /// <summary>
    /// 公共接口
    /// </summary>
    [MyVersion("My")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PublicServiceController : ControllerBase
    {
        /// <summary>
        /// 枚举接口
        /// </summary>
        private readonly IEnumAppService _enumAppService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="enumAppService"></param>
        public PublicServiceController(IEnumAppService enumAppService)
        {
            this._enumAppService = enumAppService;
        }

        /// <summary>
        /// 获取枚举描述的集合
        /// </summary>
        /// <param name="inDto">获取枚举描述输入dto</param>
        /// <returns>数据枚举描述集合</returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<List<EnumOutDto>> GetEnumArray(EnumInDto inDto)
        {
            var result = await this._enumAppService.GetEnumArray(inDto);
            return await Task.FromResult(result);
        }



    }
}