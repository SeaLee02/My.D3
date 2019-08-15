using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using My.D3.Application.PublicService.AppServices.Enum;
using My.D3.Application.Repositories;
using My.D3.Application.Test.TestDatas;
using My.D3.DataAccess.Framework;
using My.D3.Entity.Demo;
using My.D3.Entity.Demo.View;
using My.D3.Util.Configuration;
using My.D3.Util.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace My.D3.Application.Test
{
    public class DbFixture
    {
        public IContainer Container { get; private set; }

        public DbFixture()
        {
            var builder = new ContainerBuilder();
            var option = new DbContextOptionsBuilder<MyDbContext>().
                UseSqlServer("server=.;database=DD;uid=sa;pwd=123")
                .Options; //连接数据库
            //内存数据库
            var option2 = new DbContextOptionsBuilder<MyDbContext>().UseInMemoryDatabase("My.D3").Options;
            MyDbContext context = new MyDbContext(option2);

            //InitializeDbForTests  初始化测试数据
            new TestDataBuilder(context).Build();


            builder.RegisterInstance(context).As<MyDbContext>();
            //注入
            Server.ContentRootPath = Path.GetFullPath(@"..\..\..\..\..\") + @"src\My.D3";
            IConfigurationRoot configuration = AppConfigurationHelper.Get(Server.ContentRootPath);
            builder.RegisterType<SimpleDbContextProvider<MyDbContext>>().As<IDbContextProvider<MyDbContext>>().InstancePerLifetimeScope();
            var assemblysServices = Assembly.Load("My.D3.Application");
            builder.RegisterAssemblyTypes(assemblysServices).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(DbFixture).GetTypeInfo().Assembly);

            Container = builder.Build();
        }
    }
}
