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

namespace My.D3.Application.Repositories.Demo
{
    public class MyDemoStudentRepository : MyRepositoriesBase<DemoStudentEntity, Guid, DemoStudentDto, ViewDemoStudent>, IMyDemoStudentRepository
    {
        private readonly MyDbContext _db;
        private readonly IMapper _mapper;

        /// <summary>
        /// 构造函数
        /// </summary>
        public MyDemoStudentRepository(MyDbContext db, IMapper mapper) : base(db, mapper)
        {
            this._db = db;
            this._mapper = mapper;
        }

    }
}