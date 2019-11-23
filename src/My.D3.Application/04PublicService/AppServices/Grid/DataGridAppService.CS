namespace My.D3.Application.PublicService.AppServices.Grid
{
    using AutoMapper;
    using GridData.Core;
    using My.D3.Application.Repositories;
    using My.D3.DataAccess.Framework;
    using My.D3.DataAccess.Framework.Configuration;
    using My.D3.Util.Extensions;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using Z.Expressions;

    /// <summary>
    /// 数据接口
    /// </summary>
    public interface IDataGridAppService
    {

        /// <summary>
        /// 获取Gird的数据(Mapper)
        /// </summary>
        /// <param name="inDto">表格接收参数</param>
        /// <returns>grid</returns>
        Task<string> GetGridMapperList(GetGridListInDto inDto);

        /// <summary>
        /// 获取Gird的数据
        /// </summary>
        /// <param name="inDto">表格接收参数</param>
        /// <returns>grid</returns>
        Task<string> GetGridList(GetGridListInDto inDto);

        /// <summary>
        /// Linq字符串查询
        /// </summary>
        /// <returns></returns>
        Task<string> GetTest();
    }

    /// <summary>
    /// 枚举接口
    /// </summary>
    public class DataGridAppService : IDataGridAppService
    {
        private readonly IDbContextProvider<MyDbContext> _dbContextProvider;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbContextProvider">上下文</param>
        public DataGridAppService(IDbContextProvider<MyDbContext> dbContextProvider)
        {
            this._dbContextProvider = dbContextProvider;
        }

        /// <summary>
        /// 获取Gird的数据
        /// </summary>
        /// <param name="inDto">表格接收参数</param>
        /// <returns>grid</returns>
        public async Task<string> GetGridList(GetGridListInDto inDto)
        {
            string viewName = inDto.ViewName.ToCamel();
            if (!string.IsNullOrEmpty(inDto.Sort))
            {
                inDto.Order = inDto.Sort + " " + inDto.Order;
            }

            if (!string.IsNullOrEmpty(inDto.Select))
            {
                inDto.Select = $"new({inDto.Select})";
            }

            PagedInputDto pagedInputDto = new PagedInputDto()
            {
                PageSize = inDto.limit.ToString().ToDefault(99999),
                PageIndex = inDto.page.ToString().ToDefault(1),
                Order = inDto.Order,
                Select = inDto.Select
            };
            if (!string.IsNullOrEmpty(inDto.Filter))
            {
                pagedInputDto.Filter = JsonConvert.DeserializeObject<PageFilterDto>(inDto.Filter);
            }

            MyDbContext db = this._dbContextProvider.GetDbContext();
            PropertyInfo prop = db.GetType().GetProperty(viewName);
            object propVaule = prop.GetValue(db, null);

            Assembly autoAssembly = Assembly.Load("GridData.Core");
            string viewFullName = $"My.D3.Entity.Demo.View.{viewName}";
            Assembly assembly = Assembly.Load("My.D3.Entity");
            Type curType = assembly.GetType(viewFullName);
            MethodInfo pageMethodinfo = autoAssembly.GetExtensionMethods("GetPageEntityOrViewAsync").FirstOrDefault();
            dynamic result = await pageMethodinfo.MakeGenericMethod(curType)
              .InvokeAsync(null, new object[] { propVaule, pagedInputDto });

            GridResult gridResult = new GridResult
            {
                data = result.DataList,
                count = result.RowCount
            };

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Error, //忽略循环引用，如果设置为Error，则遇到循环引用的时候报错（建议设置为Error，这样更规范）
                DateFormatString = "yyyy-MM-dd HH:mm:ss", //日期格式化，默认的格式也不好看
                ContractResolver = new CamelCasePropertyNamesContractResolver() //json中属性开头字母小写的驼峰命名
            };
            return JsonConvert.SerializeObject(gridResult, settings);
        }

        /// <summary>
        /// 获取Gird的数据(Mapper)
        /// </summary>
        /// <param name="inDto">表格接收参数</param>
        /// <returns>grid</returns>
        public async Task<string> GetGridMapperList(GetGridListInDto inDto)
        {
            string viewName = inDto.ViewName.ToCamel();
            if (!string.IsNullOrEmpty(inDto.Sort))
            {
                inDto.Order = inDto.Sort + " " + inDto.Order;
            }

            if (!string.IsNullOrEmpty(inDto.Select))
            {
                inDto.Select = $"new({inDto.Select})";
            }

            PagedInputDto pagedInputDto = new PagedInputDto()
            {
                PageSize = inDto.limit.ToString().ToDefault(99999),
                PageIndex = inDto.page.ToString().ToDefault(1),
                Order = inDto.Order,
                Select = inDto.Select,
                configurationProvider = inDto.configurationProvider
            };
            if (!string.IsNullOrEmpty(inDto.Filter))
            {
                pagedInputDto.Filter = JsonConvert.DeserializeObject<PageFilterDto>(inDto.Filter);
            }

            MyDbContext db = this._dbContextProvider.GetDbContext();
            PropertyInfo prop = db.GetType().GetProperty(viewName);
            object propVaule = prop.GetValue(db, null);

            Assembly autoAssembly = Assembly.Load("GridData.Core");
            string viewFullName = $"My.D3.Entity.Demo.View.{viewName}";
            string viewModel = $"My.D3.Entity.Demo.Dto.{viewName}Dto";
            Assembly assembly = Assembly.Load("My.D3.Entity");
            Type curType = assembly.GetType(viewFullName);
            Type resultModel = assembly.GetType(viewModel);
            MethodInfo pageMethodinfo = autoAssembly.GetExtensionMethods("GetPageAsync").FirstOrDefault();
            dynamic result = await pageMethodinfo.MakeGenericMethod(curType, resultModel)
              .InvokeAsync(null, new object[] { propVaule, pagedInputDto });

            GridResult gridResult = new GridResult
            {
                data = result.DataList,
                count = result.RowCount
            };

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Error, //忽略循环引用，如果设置为Error，则遇到循环引用的时候报错（建议设置为Error，这样更规范）
                DateFormatString = "yyyy-MM-dd HH:mm:ss", //日期格式化，默认的格式也不好看
                ContractResolver = new CamelCasePropertyNamesContractResolver() //json中属性开头字母小写的驼峰命名
            };
            return JsonConvert.SerializeObject(gridResult, settings);
        }

        /// <summary>
        /// Linq字符串查询
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetTest()
        {
            MyDbContext db = this._dbContextProvider.GetDbContext();
            string name = "sealee";
            var views = "db.DemoStudent.Where(x => x.StuName ==name).ToList()".Execute<dynamic>(new { db, name });

            string aa = "";


            return await Task.FromResult("ok");
        }
    }
}
