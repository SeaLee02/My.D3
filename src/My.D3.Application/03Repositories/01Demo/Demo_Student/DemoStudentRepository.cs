namespace My.D3.Application.Repositories.Demo
{
    using AutoMapper;
    using My.D3.DataAccess.Framework;
    using My.D3.Entity.Demo;
    using My.D3.Entity.Demo.Dto;
    using My.D3.Entity.Demo.View;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DemoStudentRepository : RepositoriesBase<DemoStudentEntity, Guid, DemoStudentDto, ViewDemoStudent>, IDemoStudentRepository
    {

        private readonly MyDbContext _db;
        private readonly IMapper _mapper;

        /// <summary>
        /// 构造函数
        /// </summary>
        public DemoStudentRepository(MyDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            this._db = dbContext;
            this._mapper = mapper;
        }

        /// <summary>
        /// 从写这个方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override Task<DemoStudentDto> CreateByDtoAsync(DemoStudentDto input)
        {
            return base.CreateByDtoAsync(input);
        }
    }
}
