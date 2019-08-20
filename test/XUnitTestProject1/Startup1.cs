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
using My.D3.Application.Repositories;
using My.D3.DataAccess.Framework;
using My.D3.Util.Web;
using My.D3;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using My.D3.Util.Configuration;

namespace XUnitTestProject1
{
    public class Startup1
    {
        public Startup1(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            //IConfigurationBuilder builder = new ConfigurationBuilder()
            //   .SetBasePath(hostingEnvironment.ContentRootPath)
            //   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            //   .AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json", optional: true);

            Server.ContentRootPath = Path.GetFullPath(@"..\..\..\..\..\") + @"src\My.D3";

            // 初始化config的配置为了读取appjson文件
            IConfigurationRoot configuration2 = AppConfigurationHelper.Get(Server.ContentRootPath);

            Configuration = configuration2;
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

            //jwt授权
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("sdfsdfsrty45634kkhllghtdgdfss345t678fs")),
                    ValidateIssuer = true,
                    ValidIssuer = "issuer",
                    ValidateAudience = true,
                    ValidAudience = "audience",

                };
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        // 如果过期，则把<是否过期>添加到，返回头信息中
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });



            #region 连接数据库
            //连接数据
            string aa = Configuration["ConnectionStrings:SqlServerConnection"];
            string path = Configuration.GetConnectionString("SqlServerConnection");
            services.AddDbContext<MyDbContext>(options =>
            {
                options.UseInMemoryDatabase("My.D3");
                //初始化数据
                var dd = options.Options as DbContextOptions<MyDbContext>;
                MyDbContext myDb = new MyDbContext(dd);
                //初始化数据
                new TestDataBuilder(myDb).Build();
            });

            #endregion

            #region AutoMapper
            services.AddAutoMapper(typeof(Startup));
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
            var assemblysServices = Assembly.Load("My.D3.Application");
            builder.RegisterAssemblyTypes(assemblysServices).AsImplementedInterfaces();
            //注册上下文
            builder.RegisterType<MyDbContext>().As<MyDbContext>().InstancePerLifetimeScope();
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
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: "areas",
                   template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
