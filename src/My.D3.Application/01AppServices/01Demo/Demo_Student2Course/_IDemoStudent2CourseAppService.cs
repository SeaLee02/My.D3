namespace My.D3.Application.AppServices.Demo
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
    /// 学生课程表应用层服务
    /// </summary>
    public interface IDemoStudent2CourseAppService : IAppServicesBase<DemoStudent2CourseEntity, Guid, DemoStudent2CourseDto, ViewDemoStudent2Course>
    {

    }
}
