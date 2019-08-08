﻿namespace My.D3.Application.AppServices.Demo
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
    /// 课程表应用层服务
    /// </summary>
    public interface IDemoCourseAppService : IAppServicesBase<DemoCourseEntity, Guid, DemoCourseDto, ViewDemoCourse>
    {

    }
}
