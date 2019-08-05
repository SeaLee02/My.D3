using AutoMapper;
using GridData.Core;
using My.D3.DataAccess.Framework;
using My.D3.Entity.Framework.Dto;
using My.D3.Entity.Framework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.D3.Application.Repositories
{
    /// <summary>
    ///  response基类
    /// </summary>
    /// <typeparam name="TEntity">实体对象</typeparam>
    /// <typeparam name="TPrimaryKey">主键的类型</typeparam>
    /// <typeparam name="TEntityDto">实体展示的类型</typeparam>
    /// <typeparam name="TViewDto">viewDto的展示</typeparam>
    public class RepositoriesBase<TEntity, TPrimaryKey, TEntityDto, TViewDto> :
        IRepositoriesBase<TEntity, TPrimaryKey, TEntityDto, TViewDto>
        where TEntity : class, IEntity<TPrimaryKey>
        where TEntityDto : class, IEntityDto<TPrimaryKey>
        where TViewDto : class
    {
        private readonly MyDbContext _db;
        private readonly IMapper _mapper;

        /// <summary>
        /// 仓储构造方法
        /// </summary>
        /// <param name="db">数据库连接</param>
        /// <param name="mapper">映射</param>
        public RepositoriesBase(MyDbContext db, IMapper mapper)
        {
            this._db = db;
            this._mapper = mapper;
        }


        public Task BatchDeleteAsync(TPrimaryKey[] ids)
        {
            throw new NotImplementedException();
        }

        public Task<TEntityDto> CreateByDtoAsync(TEntityDto input)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntityDto>> GetAllListDtoAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<TDto>> GetAllListDtoAsync<TDto>()
        {
            throw new NotImplementedException();
        }

        public Task<TEntityDto> GetDtoAsync(TPrimaryKey primaryKey)
        {
            throw new NotImplementedException();
        }

        public Task<TDto> GetDtoAsync<TDto>(TPrimaryKey primaryKey)
        {
            throw new NotImplementedException();
        }

        public Task<MyPagedResult<TEntityDto>> GetPageAsync(PagedInputDto pagedInputDto)
        {
            throw new NotImplementedException();
        }

        public Task<TViewDto> GetViewDtoAsync(TPrimaryKey primaryKey)
        {
            throw new NotImplementedException();
        }

        public Task<MyPagedResult<TViewDto>> GetViewPageAsync(PagedInputDto pagedInputDto)
        {
            throw new NotImplementedException();
        }

        public Task<TEntityDto> UpdateByDtoAsync(TEntityDto input)
        {
            throw new NotImplementedException();
        }
    }
}
