namespace My.D3.Areas.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using My.D3.Application.PublicService.AppServices.Enum;
    using My.D3.Application.PublicService.AppServices.Grid;
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
        //数据接口
        private readonly IDataGridAppService _dataGridAppService;

        private readonly IMapper _mapper;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="enumAppService"></param>
        /// <param name="dataGridAppService"></param>
        public PublicServiceController(IEnumAppService enumAppService, IDataGridAppService dataGridAppService, IMapper mapper)
        {
            this._enumAppService = enumAppService;
            this._dataGridAppService = dataGridAppService;
            this._mapper = mapper;
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


        /// <summary>
        /// 获取Gird的数据
        /// </summary>
        /// <param name="inDto">表格接收参数</param>
        /// <returns>grid</returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<string> GetGridList(GetGridListInDto inDto)
        {
            var result = await this._dataGridAppService.GetGridList(inDto);
            return await Task.FromResult(result);
        }

        /// <summary>
        /// 获取Gird Mapper的数据
        /// </summary>
        /// <param name="inDto">表格接收参数</param>
        /// <returns>grid</returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<string> GetGridMapperList(GetGridListInDto inDto)
        {
            inDto.configurationProvider = _mapper.ConfigurationProvider;
            var result = await this._dataGridAppService.GetGridMapperList(inDto);
            return await Task.FromResult(result);
        }

        /// <summary>
        /// Linq字符串查询
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public async Task<string> GetTest()
        {
            var result = await this._dataGridAppService.GetTest();
            return await Task.FromResult(result);
        }
    }
}