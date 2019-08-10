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

    public class DemoSchoolAppService : IDemoSchoolAppService
    {
        private readonly IDemoSchoolRepository _demoSchoolRepository;
        public DemoSchoolAppService(IDemoSchoolRepository demoSchoolRepository)
        {
            this._demoSchoolRepository = demoSchoolRepository;
        }

        /// <summary>
        /// 获取单个  [学院表]  的dto
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>单个对象的dto</returns>
        public async Task<DemoSchoolDto> GetDto(Guid id)
        {
            var dto = await this._demoSchoolRepository.GetDtoAsync(id);
            return dto;
        }

        /// <summary>
        /// 获取单个  [学院表] 视图的dto
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>单个对象的dto</returns>
        public async Task<ViewDemoSchool> GetViewDto(Guid id)
        {
            var dto = await this._demoSchoolRepository.GetViewDtoAsync(id);
            return dto;
        }

        /// <summary>
        /// 获取  [学院表] 视图分页的信息
        /// </summary>
        /// <param name="pagedInputDto">分页输入的Dto</param>
        /// <returns>分页信息</returns>
        public async Task<MyPagedResult<ViewDemoSchool>> GetViewPage(PagedInputDto pagedInputDto)
        {
            var pagedResult = await this._demoSchoolRepository.GetViewPageAsync(pagedInputDto);
            return pagedResult;
        }

        /// <summary>
        /// 获取  [学院表] 分页的信息
        /// </summary>
        /// <param name="pagedInputDto">分页输入的Dto</param>
        /// <returns>分页信息</returns>
        public async Task<MyPagedResult<DemoSchoolDto>> GetPage(PagedInputDto pagedInputDto)
        {
            var pagedResult = await this._demoSchoolRepository.GetPageAsync(pagedInputDto);
            return pagedResult;
        }

        /// <summary>
        /// 获取 [学院表] 的所有信息
        /// </summary>
        /// <returns>list集合</returns>
        public async Task<List<DemoSchoolDto>> GetAllListDto()
        {
            var listResult = await this._demoSchoolRepository.GetAllListDtoAsync();
            return listResult;
        }



        /// <summary>
        /// 创建  [学院表]
        /// </summary>
        /// <param name="input">创建输入实体</param>
        /// <returns>输出dto</returns>
        public async Task<DemoSchoolDto> CreateByDto(DemoSchoolDto input)
        {
            var dto = await this._demoSchoolRepository.CreateByDtoAsync(input);
            return dto;
        }

        /// <summary>
        /// 更新  [学院表]
        /// </summary>
        /// <param name="input">更新的实体的对象</param>
        /// <returns>更新后的对象</returns>
        public async Task<DemoSchoolDto> UpdateByDto(DemoSchoolDto input)
        {
            var dto = await this._demoSchoolRepository.UpdateByDtoAsync(input);
            return dto;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">实体的id</param>
        /// <returns>task 空值</returns>
        public async Task Delete(Guid id)
        {
            await this._demoSchoolRepository.DeleteAsync(id);
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
            await this._demoSchoolRepository.BatchDeleteAsync(newIds.ToArray());
        }
    }
}
