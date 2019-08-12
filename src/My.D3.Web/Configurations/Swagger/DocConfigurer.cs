using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using My.D3.Util.Web;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.IO;
using System.Linq;
using System.Reflection;

namespace My.D3.Configurations
{
    /// <summary>
    /// 配置文档生成
    /// </summary>
    public static class DocConfigurer
    {
        /// <summary>
        /// 配置文档生成
        /// </summary>
        /// <param name="services">程序的服务对象</param>
        /// <param name="configuration">程序的配置对象</param>
        /// <param name="env">环境节点</param>
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration, IHostingEnvironment env)
        {
            if (!env.IsProduction())
            {
                services.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("T1", new Info { Title = "测试" });
                    options.SwaggerDoc("T2", new Info { Title = "真棒" });

                    options.DocInclusionPredicate((docName, apiDesc) =>
                    {
                        if (!apiDesc.TryGetMethodInfo(out MethodInfo methodInfo))
                        {
                            return false;
                        }

                        System.Collections.Generic.IEnumerable<string> versions = methodInfo.DeclaringType
                            .GetCustomAttributes(true)
                            .OfType<MyVersionAttribute>()
                            .Select(attr => attr.Version);

                        return versions.Any(v => $"{v.ToString()}" == docName);
                    });

                    // Define the BearerAuth scheme that's in use
                    //页面可以显示自定义的授权按钮
                    options.AddSecurityDefinition("bearerAuth", new ApiKeyScheme()
                    {
                        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                        Name = "Authorization",
                        In = "header",
                        Type = "apiKey"
                    });

                    // Assign scope requirements to operations based on AuthorizeAttribute
                    options.OperationFilter<SecurityRequirementsOperationFilter>();

                    string xmlCommentsPath = Path.Combine(Server.BinPath, "My.D3.Application.xml");
                    options.IncludeXmlComments(xmlCommentsPath, true);

                    xmlCommentsPath = Path.Combine(Server.BinPath, "My.D3.xml");
                    options.IncludeXmlComments(xmlCommentsPath, true);

                    //string path = System.AppDomain.CurrentDomain.BaseDirectory;
                    //string _xmlPath = string.Format("{0}/bin/My.D3.xml", path);
                    //options.IncludeXmlComments(_xmlPath, true);

                    xmlCommentsPath = Path.Combine(Server.BinPath, "My.D3.Entity.xml");
                    options.IncludeXmlComments(xmlCommentsPath, true);
                });
            }

        }

        /// <summary>
        /// 文档的配置
        /// </summary>
        /// <param name="app">app环境</param>
        /// <param name="env">env的环境</param>
        public static void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (!env.IsProduction())
            {
                //app.UseMiddleware<SwaggerCacheMiddleware>(CacheAppConsts.WebSiteCache);
                app.UseSwagger(c =>
                {
                    c.PreSerializeFilters.Add((swaggerDoc, httpReq) => swaggerDoc.Host = httpReq.Host.Value);
                    c.RouteTemplate = "api/doc/{documentName}/swagger.json";
                });
                app.UseSwaggerUI(options =>
                {
                    options.RoutePrefix = "api/doc";
                    options.SwaggerEndpoint("/api/doc/T1/swagger.json", "你真棒");
                    options.SwaggerEndpoint("/api/doc/T2/swagger.json", "可以的");
                    options.IndexStream = () => Assembly.GetExecutingAssembly()
                    .GetManifestResourceStream("My.D3.wwwroot.swagger.ui.Index.html");
                    options.EnableFilter();
                    options.DocExpansion(DocExpansion.None);
                    options.DefaultModelsExpandDepth(-1);
                });
            }

        }
    }
}
