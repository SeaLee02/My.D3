namespace My.D3.Application.AppServices.Demo22
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
    /// 应用层服务
    /// </summary>
    public interface IDemoStudentAppService : IAppServicesBase<DemoStudentEntity, Guid, DemoStudentDto, ViewDemoStudent>
    {

    }
}
