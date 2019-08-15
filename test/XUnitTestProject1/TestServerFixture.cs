using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using My.D3.DataAccess.Framework;
using My.D3.Entity.Demo;
using My.D3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTestProject1
{
    public class TestServerFixture : IDisposable
    {
        private readonly TestServer _testServer;

        public HttpClient Client { get; }

        public TestServerFixture()
        {
            var bulild = new WebHostBuilder().UseStartup<Startup1>();

            _testServer = new TestServer(bulild);
            var option2 = new DbContextOptionsBuilder<MyDbContext>().UseInMemoryDatabase("My.D3").Options;
            MyDbContext context = new MyDbContext(option2);

            context.DemoStudent.Add(new DemoStudentEntity
            {
                StuName = "aaaa2222",
                IsDeleted = 0
            });

            context.SaveChanges();

            Client = _testServer.CreateClient();
        }

        public void Dispose()
        {
            Client.Dispose();
            _testServer.Dispose();
        }
    }
}
