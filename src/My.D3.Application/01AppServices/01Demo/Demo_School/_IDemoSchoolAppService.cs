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
    /// 学院表应用层服务
    /// </summary>
    public interface IDemoSchoolAppService : IAppServicesBase<DemoSchoolEntity, Guid, DemoSchoolDto, ViewDemoSchool>
    {

    }
}
