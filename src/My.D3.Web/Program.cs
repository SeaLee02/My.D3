using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Autofac.Extensions.DependencyInjection;

namespace My.D3.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var host = WebHost.CreateDefaultBuilder(args)
            //  .ConfigureServices(services => services.AddAutofac())
            //  .UseStartup<Startup>()
            //  .Build();
            //host.Run();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                        .UseStartup<Startup>();
        }
    }
}
