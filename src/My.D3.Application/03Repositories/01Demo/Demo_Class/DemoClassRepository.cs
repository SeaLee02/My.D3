namespace  My.D3.Application.Repositories.Demo
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using My.D3.DataAccess.Framework;
    using My.D3.Entity.Demo;
    using My.D3.Entity.Demo.Dto;
    using My.D3.Entity.Demo.View;

    /// <summary>
    /// 班级表仓储接口
    /// </summary>
    public class DemoClassRepository : RepositoriesBase<DemoClassEntity,  Guid, DemoClassDto, ViewDemoClass>, IDemoClassRepository
    {

        private readonly MyDbContext _db;
        private readonly IMapper _mapper;

        /// <summary>
        /// 构造函数
        /// </summary>
        public DemoClassRepository(MyDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            this._db = dbContext;
            this._mapper = mapper;
        }

    }
}

