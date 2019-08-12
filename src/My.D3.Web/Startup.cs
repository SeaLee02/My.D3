using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using My.D3.Application.AppServices.Demo;
using My.D3.Application.Repositories;
using My.D3.Application.Repositories.Demo;
using My.D3.Configurations;
using My.D3.DataAccess.Framework;

namespace My.D3.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            this._env = hostingEnvironment;
        }

        private readonly IHostingEnvironment _env;
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            #region AutoMapper
            services.AddAutoMapper(typeof(Startup));
            #endregion

            #region 连接数据库
            //连接数据
            string path = Configuration.GetConnectionString("SqlServerConnection");
            services.AddDbContext<MyDbContext>(options => options.UseSqlServer(path));
            #endregion

            #region SwaggerUI
            DocConfigurer.ConfigureServices(services, this.Configuration, this._env);
            #endregion


            #region 依赖注入
            //微软自带
            //services.AddScoped<IDbContextProvider<MyDbContext>, SimpleDbContextProvider<MyDbContext>>();
            //services.AddScoped<IDemoStudentAppService, DemoStudentAppService>();
            //services.AddScoped<IDemoStudentRepository, DemoStudentRepository>();
            //services.AddScoped<IMyDemoStudentAppService, MyDemoStudentAppService>();
            //services.AddScoped<IMyDemoStudentRepository, MyDemoStudentRepository>();

            //实例化 AutoFac  容器   
            var builder = new ContainerBuilder();
            var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;
            var servicesDllFile = Path.Combine(basePath, "My.D3.Application.dll");
            var assemblysServices = Assembly.LoadFrom(servicesDllFile);
            builder.RegisterAssemblyTypes(assemblysServices).AsImplementedInterfaces();
            //注册上下文
            builder.RegisterType<SimpleDbContextProvider<MyDbContext>>().As<IDbContextProvider<MyDbContext>>().InstancePerLifetimeScope();

            //将services填充到Autofac容器生成器中
            builder.Populate(services);
            //使用已进行的组件登记创建新容器
            var ApplicationContainer = builder.Build();
            return new AutofacServiceProvider(ApplicationContainer);//第三方IOC接管 core内置DI容器  
                                                                    //IServiceProvider  返回这个
            #endregion


        }


        //public void ConfigureContainer(ContainerBuilder builder)
        //{
        //    // Add any Autofac modules or registrations.
        //    // This is called AFTER ConfigureServices so things you
        //    // register here OVERRIDE things registered in ConfigureServices.
        //    //
        //    // You must have the call to AddAutofac in the Program.Main
        //    // method or this won't be called.
        //    builder.RegisterModule(new AutofacModule());
        //}


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: "areas",
                   template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            DocConfigurer.Configure(app, env);
        }
    }
}
