namespace My.D3.Areas.Api.Controllers.Demo
{
    using GridData.Core;
    using Microsoft.AspNetCore.Mvc;
    using My.D3.Application.AppServices.Demo;
    using My.D3.Application.Framework.Dto;
    using My.D3.Configurations;
    using My.D3.Entity.Demo.Dto;
    using My.D3.Entity.Demo.View;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 课程表接口
    /// </summary>
    [MyVersion("Demo")]
    [Route("api/[controller]")]
    [ApiController]
    public class APIDemoCourseController : ControllerBase
    {
        private readonly IDemoCourseAppService _demoCourseAppService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="demoCourseAppService"></param>
        public APIDemoCourseController(IDemoCourseAppService demoCourseAppService)
        {
            this._demoCourseAppService = demoCourseAppService;
        }

        /// <summary>
        /// 获取单个  [课程表]  的dto
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>单个对象的dto</returns>
        [HttpPost("GetDto")]
        public async Task<DemoCourseDto> GetDto(Guid id)
        {
            var dto = await this._demoCourseAppService.GetDto(id);
            return await Task.FromResult(dto);
        }

        /// <summary>
        /// 获取单个  [应用系统表] 视图的dto
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>单个对象的dto</returns>
        [HttpPost("GetViewDto")]
        public async Task<ViewDemoCourse> GetViewDto(Guid id)
        {
            var dto = await this._demoCourseAppService.GetViewDto(id);
            return dto;
        }

        /// <summary>
        /// 获取  [应用系统表] 视图分页的信息
        /// </summary>
        /// <param name="pagedInputDto">分页输入的Dto</param>
        /// <returns>分页信息</returns>
        [HttpPost("GetViewPage")]
        public async Task<MyPagedResult<ViewDemoCourse>> GetViewPage(PagedInputDto pagedInputDto)
        {
            var pagedResult = await this._demoCourseAppService.GetViewPage(pagedInputDto);
            return pagedResult;
        }

        /// <summary>
        /// 获取  [应用系统表] 分页的信息
        /// </summary>
        /// <param name="pagedInputDto">分页输入的Dto</param>
        /// <returns>分页信息</returns>
        [HttpPost("GetPage")]
        public async Task<MyPagedResult<DemoCourseDto>> GetPage(PagedInputDto pagedInputDto)
        {
            var pagedResult = await this._demoCourseAppService.GetPage(pagedInputDto);
            return pagedResult;
        }

        /// <summary>
        /// 获取 [应用系统表] 的所有信息
        /// </summary>
        /// <returns>list集合</returns>
        [HttpPost("GetAllListDto")]
        public async Task<List<DemoCourseDto>> GetAllListDto()
        {
            var listResult = await this._demoCourseAppService.GetAllListDto();
            return listResult;
        }

        /// <summary>
        /// 创建  [应用系统表]
        /// </summary>
        /// <param name="input">创建输入实体</param>
        /// <returns>输出dto</returns>
        [HttpPost("CreateByDto")]
        public async Task<DemoCourseDto> CreateByDto(DemoCourseDto input)
        {
            var dto = await this._demoCourseAppService.CreateByDto(input);
            return dto;
        }

        /// <summary>
        /// 更新  [应用系统表]
        /// </summary>
        /// <param name="input">更新的实体的对象</param>
        /// <returns>更新后的对象</returns>
        [HttpPost("UpdateByDto")]
        public async Task<DemoCourseDto> UpdateByDto(DemoCourseDto input)
        {
            var dto = await this._demoCourseAppService.UpdateByDto(input);
            return dto;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="deleteDto"></param>
        /// <returns></returns>
        [HttpPost("BatchDelete")]
        public async Task BatchDelete(DeleteDto deleteDto)
        {
            await this._demoCourseAppService.BatchDelete(deleteDto);
        }
    }
}
