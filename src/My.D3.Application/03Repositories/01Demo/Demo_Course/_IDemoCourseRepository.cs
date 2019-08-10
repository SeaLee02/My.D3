namespace  My.D3.Application.Repositories.Demo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using My.D3.Entity.Demo;
    using My.D3.Entity.Demo.Dto;
    using My.D3.Entity.Demo.View;

    /// <summary>
    /// 课程表仓储接口
    /// </summary>
    public interface IDemoCourseRepository : IRepository<DemoCourseEntity, Guid>,IRepositoriesBase<DemoCourseEntity, Guid, DemoCourseDto, ViewDemoCourse>
    {

    }
}
