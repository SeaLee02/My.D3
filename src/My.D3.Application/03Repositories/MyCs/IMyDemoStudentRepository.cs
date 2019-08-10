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
    public interface IMyDemoStudentRepository : IRepository<DemoStudentEntity, Guid>, IRepositoriesBase<DemoStudentEntity, Guid, DemoStudentDto, ViewDemoStudent>
    {

    }
}
