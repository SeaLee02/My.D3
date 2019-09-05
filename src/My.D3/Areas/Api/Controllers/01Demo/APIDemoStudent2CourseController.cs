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
    /// 学生课程表接口
    /// </summary>
    [MyVersion("Demo")]
    [Route("api/[controller]")]
    [ApiController]
    public class APIDemoStudent2CourseController : ControllerBase
    {
        private readonly IDemoStudent2CourseAppService _demoStudent2CourseAppService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="demoStudent2CourseAppService"></param>
        public APIDemoStudent2CourseController(IDemoStudent2CourseAppService demoStudent2CourseAppService)
        {
            this._demoStudent2CourseAppService = demoStudent2CourseAppService;
        }

        /// <summary>
        /// 获取单个  [学生课程表]  的dto
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>单个对象的dto</returns>
        [HttpPost("GetDto")]
        public async Task<DemoStudent2CourseDto> GetDto(Guid id)
        {
            var dto = await this._demoStudent2CourseAppService.GetDto(id);
            return await Task.FromResult(dto);
        }

        /// <summary>
        /// 获取单个  [应用系统表] 视图的dto
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>单个对象的dto</returns>
        [HttpPost("GetViewDto")]
        public async Task<ViewDemoStudent2Course> GetViewDto(Guid id)
        {
            var dto = await this._demoStudent2CourseAppService.GetViewDto(id);
            return dto;
        }

        /// <summary>
        /// 获取  [应用系统表] 视图分页的信息
        /// </summary>
        /// <param name="pagedInputDto">分页输入的Dto</param>
        /// <returns>分页信息</returns>
        [HttpPost("GetViewPage")]
        //public async Task<MyPagedResult<ViewDemoStudent2Course>> GetViewPage(PagedInputDto pagedInputDto)
        //{
        //    var pagedResult = await this._demoStudent2CourseAppService.GetViewPage(pagedInputDto);
        //    return pagedResult;
        //}

        /// <summary>
        /// 获取  [应用系统表] 分页的信息
        /// </summary>
        /// <param name="pagedInputDto">分页输入的Dto</param>
        /// <returns>分页信息</returns>
        [HttpPost("GetPage")]
        public async Task<MyPagedResult<DemoStudent2CourseDto>> GetPage(PagedInputDto pagedInputDto)
        {
            var pagedResult = await this._demoStudent2CourseAppService.GetPage(pagedInputDto);
            return pagedResult;
        }

        /// <summary>
        /// 获取 [应用系统表] 的所有信息
        /// </summary>
        /// <returns>list集合</returns>
        [HttpPost("GetAllListDto")]
        public async Task<List<DemoStudent2CourseDto>> GetAllListDto()
        {
            var listResult = await this._demoStudent2CourseAppService.GetAllListDto();
            return listResult;
        }

        /// <summary>
        /// 创建  [应用系统表]
        /// </summary>
        /// <param name="input">创建输入实体</param>
        /// <returns>输出dto</returns>
        [HttpPost("CreateByDto")]
        public async Task<DemoStudent2CourseDto> CreateByDto(DemoStudent2CourseDto input)
        {
            var dto = await this._demoStudent2CourseAppService.CreateByDto(input);
            return dto;
        }

        /// <summary>
        /// 更新  [应用系统表]
        /// </summary>
        /// <param name="input">更新的实体的对象</param>
        /// <returns>更新后的对象</returns>
        [HttpPost("UpdateByDto")]
        public async Task<DemoStudent2CourseDto> UpdateByDto(DemoStudent2CourseDto input)
        {
            var dto = await this._demoStudent2CourseAppService.UpdateByDto(input);
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
            await this._demoStudent2CourseAppService.BatchDelete(deleteDto);
        }
    }
}
