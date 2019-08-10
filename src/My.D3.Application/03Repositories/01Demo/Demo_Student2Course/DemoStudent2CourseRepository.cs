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
    /// 学生课程表仓储接口
    /// </summary>
    public class DemoStudent2CourseRepository : RepositoriesBase<DemoStudent2CourseEntity,  Guid, DemoStudent2CourseDto, ViewDemoStudent2Course>, IDemoStudent2CourseRepository
    {      
        private readonly IDbContextProvider<MyDbContext> _dbContextProvider;
        private readonly IMapper _mapper;

        /// <summary>
        /// 构造函数
        /// </summary>
        public DemoStudent2CourseRepository(IDbContextProvider<MyDbContext> _dbContextProvider, IMapper mapper) : base(_dbContextProvider, mapper)
        {
            this._dbContextProvider = _dbContextProvider;
            this._mapper = mapper;
        }

    }
}

