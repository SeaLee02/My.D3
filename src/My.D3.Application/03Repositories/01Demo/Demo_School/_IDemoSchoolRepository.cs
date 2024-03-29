﻿namespace  My.D3.Application.Repositories.Demo
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
    /// 学院表仓储接口
    /// </summary>
    public interface IDemoSchoolRepository : IRepository<DemoSchoolEntity, Guid>,IRepositoriesBase<DemoSchoolEntity, Guid, DemoSchoolDto, ViewDemoSchool>
    {

    }
}
