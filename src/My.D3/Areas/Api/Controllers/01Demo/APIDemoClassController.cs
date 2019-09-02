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
    /// 班级表接口
    /// </summary>
    [MyVersion("Demo")]
    [Route("api/[controller]")]
    [ApiController]
    public class APIDemoClassController : ControllerBase
    {
       private readonly IDemoClassAppService _demoClassAppService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="demoClassAppService"></param>
        public APIDemoClassController(IDemoClassAppService demoClassAppService)
        {
            this._demoClassAppService = demoClassAppService;
        }

        /// <summary>
        /// 获取单个  [班级表]  的dto
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>单个对象的dto</returns>
        [HttpPost("GetDto")]
        public async Task<DemoClassDto> GetDto(Guid id)
        {
            var dto = await this._demoClassAppService.GetDto(id);
            return await Task.FromResult(dto);
        }

        /// <summary>
        /// 获取单个  [应用系统表] 视图的dto
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>单个对象的dto</returns>
        [HttpPost("GetViewDto")]
        public async Task<ViewDemoClass> GetViewDto(Guid id)
        {
            var dto = await this._demoClassAppService.GetViewDto(id);
            return dto;
        }

        /// <summary>
        /// 获取  [应用系统表] 视图分页的信息
        /// </summary>
        /// <param name="pagedInputDto">分页输入的Dto</param>
        /// <returns>分页信息</returns>
        [HttpPost("GetViewPage")]
        public async Task<MyPagedResult<ViewDemoClass>> GetViewPage(PagedInputDto pagedInputDto)
        {
            var pagedResult = await this._demoClassAppService.GetViewPage(pagedInputDto);
            return pagedResult;
        }

        /// <summary>
        /// 获取  [应用系统表] 分页的信息
        /// </summary>
        /// <param name="pagedInputDto">分页输入的Dto</param>
        /// <returns>分页信息</returns>
        [HttpPost("GetPage")]
        public async Task<MyPagedResult<DemoClassDto>> GetPage(PagedInputDto pagedInputDto)
        {
            var pagedResult = await this._demoClassAppService.GetPage(pagedInputDto);
            return pagedResult;
        }

        /// <summary>
        /// 获取 [应用系统表] 的所有信息
        /// </summary>
        /// <returns>list集合</returns>
        [HttpPost("GetAllListDto")]
        public async Task<List<DemoClassDto>> GetAllListDto()
        {
            var listResult = await this._demoClassAppService.GetAllListDto();
            return listResult;
        }

        /// <summary>
        /// 创建  [应用系统表]
        /// </summary>
        /// <param name="input">创建输入实体</param>
        /// <returns>输出dto</returns>
        [HttpPost("CreateByDto")]
        public async Task<DemoClassDto> CreateByDto(DemoClassDto input)
        {
            var dto = await this._demoClassAppService.CreateByDto(input);
            return dto;
        }

        /// <summary>
        /// 更新  [应用系统表]
        /// </summary>
        /// <param name="input">更新的实体的对象</param>
        /// <returns>更新后的对象</returns>
        [HttpPost("UpdateByDto")]
        public async Task<DemoClassDto> UpdateByDto(DemoClassDto input)
        {
            var dto = await this._demoClassAppService.UpdateByDto(input);
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
            await this._demoClassAppService.BatchDelete(deleteDto);
        }
    }
}
