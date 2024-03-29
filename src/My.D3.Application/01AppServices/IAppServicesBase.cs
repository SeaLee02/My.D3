﻿namespace My.D3.Application.AppServices
{
    using GridData.Core;
    using My.D3.Application.Framework.Dto;
    using My.D3.Entity.Framework.Dto;
    using My.D3.Entity.Framework.Entity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public interface IAppServicesBase<TEntity, TPrimaryKey, TEntityDto, TView>
        where TEntity : class, IEntity<TPrimaryKey>
        where TEntityDto : class, IEntityDto<TPrimaryKey>
        where TView : class, IEntity<TPrimaryKey>
    {
        /// <summary>
        /// 获取单个的viewdto对象
        /// </summary>
        /// <param name="primaryKey">获取对象转成dto</param>
        /// <returns>dto对象</returns>
        Task<TView> GetViewDto(TPrimaryKey id);

        /// <summary>
        /// 获取单个实体实体数据
        /// </summary>
        /// <param name="primaryKey">实体的ID</param>
        /// <returns>视图数据</returns>
        Task<TEntityDto> GetDto(TPrimaryKey id);

        /// <summary>
        /// 视图分页
        /// </summary>
        /// <param name="pagedInputDto">分页输入对象</param>
        /// <returns>分页对象</returns>
        Task<MyPagedResult<TView>> GetViewPage(PagedInputDto pagedInputDto);

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="pagedInputDto">分页输入</param>
        /// <returns>分页对象</returns>
        Task<MyPagedResult<TEntityDto>> GetPage(PagedInputDto pagedInputDto);

        /// <summary>
        /// 获取所有的实体数据
        /// </summary>
        /// <returns>视图数据</returns>
        Task<List<TEntityDto>> GetAllListDto();

        /// <summary>
        /// 实体创建异步
        /// </summary>
        /// <param name="input">输入对象</param>
        /// <returns>返回输出对象</returns>
        Task<TEntityDto> CreateByDto(TEntityDto input);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="input">更新输入对象</param>
        /// <returns>主键值</returns>
        Task<TEntityDto> UpdateByDto(TEntityDto input);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">更新输入对象</param>
        /// <returns>Task空值</returns>
        Task Delete(TPrimaryKey id);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids">更新输入对象</param>
        /// <returns>r任务</returns>
        Task BatchDelete(DeleteDto deleteDto);


    }
}
