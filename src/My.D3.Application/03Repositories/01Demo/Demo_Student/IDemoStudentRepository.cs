namespace My.D3.Application.Repositories.Demo
{
    using My.D3.Entity.Demo;
    using My.D3.Entity.Demo.Dto;
    using My.D3.Entity.Demo.View;
    using System;
    public interface IDemoStudentRepository : IRepositoriesBase<DemoStudentEntity, Guid, DemoStudentDto, ViewDemoStudent>
    {

    }
}
