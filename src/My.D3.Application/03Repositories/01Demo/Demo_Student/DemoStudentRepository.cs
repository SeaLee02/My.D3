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
        /// <summary>
        /// 构造函数
        /// </summary>
        public DemoStudentRepository()
        {

        }

        public override Task<DemoStudentDto> CreateByDtoAsync(DemoStudentDto input)
        {
            return base.CreateByDtoAsync(input);
        }
    }
}
