namespace My.D3.Application.AppServices.Demo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using GridData.Core;
    using My.D3.Application.Framework.Dto;
    using My.D3.Application.Repositories.Demo;
    using My.D3.Entity.Demo.Dto;
    using My.D3.Entity.Demo.View;
    using My.D3.Util.Extensions;

    public class DemoStudent2CourseAppService : IDemoStudent2CourseAppService
    {
        private readonly IDemoStudent2CourseRepository _demoStudent2CourseRepository;
        public DemoStudent2CourseAppService(IDemoStudent2CourseRepository demoStudent2CourseRepository)
        {
            this._demoStudent2CourseRepository = demoStudent2CourseRepository;
        }

        /// <summary>
        /// 获取单个  [学生课程表]  的dto
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>单个对象的dto</returns>
        public async Task<DemoStudent2CourseDto> GetDto(Guid id)
        {
            var dto = await this._demoStudent2CourseRepository.GetDtoAsync(id);
            return dto;
        }

        /// <summary>
        /// 获取单个  [学生课程表] 视图的dto
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>单个对象的dto</returns>
        public async Task<ViewDemoStudent2Course> GetViewDto(Guid id)
        {
            var dto = await this._demoStudent2CourseRepository.GetViewDtoAsync(id);
            return dto;
        }

        /// <summary>
        /// 获取  [学生课程表] 视图分页的信息
        /// </summary>
        /// <param name="pagedInputDto">分页输入的Dto</param>
        /// <returns>分页信息</returns>
        public async Task<MyPagedResult<ViewDemoStudent2Course>> GetViewPage(PagedInputDto pagedInputDto)
        {
            var pagedResult = await this._demoStudent2CourseRepository.GetViewPageAsync(pagedInputDto);
            return pagedResult;
        }

        /// <summary>
        /// 获取  [学生课程表] 分页的信息
        /// </summary>
        /// <param name="pagedInputDto">分页输入的Dto</param>
        /// <returns>分页信息</returns>
        public async Task<MyPagedResult<DemoStudent2CourseDto>> GetPage(PagedInputDto pagedInputDto)
        {
            var pagedResult = await this._demoStudent2CourseRepository.GetPageAsync(pagedInputDto);
            return pagedResult;
        }

        /// <summary>
        /// 获取 [学生课程表] 的所有信息
        /// </summary>
        /// <returns>list集合</returns>
        public async Task<List<DemoStudent2CourseDto>> GetAllListDto()
        {
            var listResult = await this._demoStudent2CourseRepository.GetAllListDtoAsync();
            return listResult;
        }



        /// <summary>
        /// 创建  [学生课程表]
        /// </summary>
        /// <param name="input">创建输入实体</param>
        /// <returns>输出dto</returns>
        public async Task<DemoStudent2CourseDto> CreateByDto(DemoStudent2CourseDto input)
        {
            var dto = await this._demoStudent2CourseRepository.CreateByDtoAsync(input);
            return dto;
        }

        /// <summary>
        /// 更新  [学生课程表]
        /// </summary>
        /// <param name="input">更新的实体的对象</param>
        /// <returns>更新后的对象</returns>
        public async Task<DemoStudent2CourseDto> UpdateByDto(DemoStudent2CourseDto input)
        {
            var dto = await this._demoStudent2CourseRepository.UpdateByDtoAsync(input);
            return dto;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">实体的id</param>
        /// <returns>task 空值</returns>
        public async Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="deleteDto"></param>
        /// <returns></returns>
        public async Task BatchDelete(DeleteDto deleteDto)
        {
            string strId = deleteDto.Id;
            IEnumerable<string> ids = strId.Split(",").Select(x => x.Replace("'", string.Empty));
            List<Guid> newIds = new List<Guid>();
            foreach (var id in ids)
            {
                newIds.Add(id.ConvertTo<Guid>());
            }
            await this._demoStudent2CourseRepository.BatchDeleteAsync(newIds.ToArray());
        }
    }
}
