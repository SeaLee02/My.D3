using Autofac;
using My.D3.Application.AppServices.Demo;
using My.D3.Application.Repositories;
using My.D3.Application.Repositories.Demo;
using My.D3.DataAccess.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.D3.Configurations
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // The generic ILogger<TCategoryName> service was added to the ServiceCollection by ASP.NET Core.
            // It was then registered with Autofac using the Populate method. All of this starts
            // with the services.AddAutofac() that happens in Program and registers Autofac
            // as the service provider

            //services.AddScoped<IMyDemoStudentAppService, MyDemoStudentAppService>();

            //services.AddScoped<IMyDemoStudentRepository, MyDemoStudentRepository>();



            builder.RegisterType<IDbContextProvider<MyDbContext>>();
            builder.RegisterType<DemoStudentAppService>().As<IDemoStudentAppService>().InstancePerLifetimeScope();
            builder.RegisterType<DemoStudentRepository>().As<IDemoStudentRepository>().InstancePerLifetimeScope();


            builder.RegisterType<MyDemoStudentAppService>().As<IMyDemoStudentAppService>().InstancePerLifetimeScope();
            builder.RegisterType<MyDemoStudentRepository>().As<IMyDemoStudentRepository>().InstancePerLifetimeScope();

            //builder.Register(c => new ValuesService(c.Resolve<ILogger<ValuesService>>()))
            //    .As<IValuesService>()
            //    .InstancePerLifetimeScope();
        }
    }
}
