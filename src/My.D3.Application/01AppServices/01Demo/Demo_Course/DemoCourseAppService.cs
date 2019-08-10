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

    public class DemoCourseAppService : IDemoCourseAppService
    {
        private readonly IDemoCourseRepository _demoCourseRepository;
        public DemoCourseAppService(IDemoCourseRepository demoCourseRepository)
        {
            this._demoCourseRepository = demoCourseRepository;
        }

        /// <summary>
        /// 获取单个  [课程表]  的dto
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>单个对象的dto</returns>
        public async Task<DemoCourseDto> GetDto(Guid id)
        {
            var dto = await this._demoCourseRepository.GetDtoAsync(id);
            return dto;
        }

        /// <summary>
        /// 获取单个  [课程表] 视图的dto
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>单个对象的dto</returns>
        public async Task<ViewDemoCourse> GetViewDto(Guid id)
        {
            var dto = await this._demoCourseRepository.GetViewDtoAsync(id);
            return dto;
        }

        /// <summary>
        /// 获取  [课程表] 视图分页的信息
        /// </summary>
        /// <param name="pagedInputDto">分页输入的Dto</param>
        /// <returns>分页信息</returns>
        public async Task<MyPagedResult<ViewDemoCourse>> GetViewPage(PagedInputDto pagedInputDto)
        {
            var pagedResult = await this._demoCourseRepository.GetViewPageAsync(pagedInputDto);
            return pagedResult;
        }

        /// <summary>
        /// 获取  [课程表] 分页的信息
        /// </summary>
        /// <param name="pagedInputDto">分页输入的Dto</param>
        /// <returns>分页信息</returns>
        public async Task<MyPagedResult<DemoCourseDto>> GetPage(PagedInputDto pagedInputDto)
        {
            var pagedResult = await this._demoCourseRepository.GetPageAsync(pagedInputDto);
            return pagedResult;
        }

        /// <summary>
        /// 获取 [课程表] 的所有信息
        /// </summary>
        /// <returns>list集合</returns>
        public async Task<List<DemoCourseDto>> GetAllListDto()
        {
            var listResult = await this._demoCourseRepository.GetAllListDtoAsync();
            return listResult;
        }



        /// <summary>
        /// 创建  [课程表]
        /// </summary>
        /// <param name="input">创建输入实体</param>
        /// <returns>输出dto</returns>
        public async Task<DemoCourseDto> CreateByDto(DemoCourseDto input)
        {
            var dto = await this._demoCourseRepository.CreateByDtoAsync(input);
            return dto;
        }

        /// <summary>
        /// 更新  [课程表]
        /// </summary>
        /// <param name="input">更新的实体的对象</param>
        /// <returns>更新后的对象</returns>
        public async Task<DemoCourseDto> UpdateByDto(DemoCourseDto input)
        {
            var dto = await this._demoCourseRepository.UpdateByDtoAsync(input);
            return dto;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">实体的id</param>
        /// <returns>task 空值</returns>
        public async Task Delete(Guid id)
        {
            await this._demoCourseRepository.DeleteAsync(id);
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
            await this._demoCourseRepository.BatchDeleteAsync(newIds.ToArray());
        }
    }
}
