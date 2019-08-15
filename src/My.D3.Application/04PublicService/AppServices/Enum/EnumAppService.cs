namespace My.D3.Application.PublicService.AppServices.Enum
{
    using My.D3.Application.Repositories;
    using My.D3.DataAccess.Framework;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading.Tasks;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// 枚举接口服务
    /// </summary>
    public interface IEnumAppService
    {
        /// <summary>
        /// 获取枚举描述的集合
        /// </summary>
        /// <param name="inDto">获取枚举描述输入dto</param>
        /// <returns>数据枚举描述集合</returns>
        Task<List<EnumOutDto>> GetEnumArray(EnumInDto inDto);
    }

    /// <summary>
    /// 枚举接口
    /// </summary>
    public class EnumAppService : IEnumAppService
    {
        private readonly IDbContextProvider<MyDbContext> _dbContextProvider;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbContextProvider">上下文</param>
        public EnumAppService(IDbContextProvider<MyDbContext> dbContextProvider)
        {
            this._dbContextProvider = dbContextProvider;
        }




        /// <summary>
        /// 获取枚举描述的集合
        /// </summary>
        /// <param name="inDto">获取枚举描述输入dto</param>
        /// <returns>数据枚举描述集合</returns>
        public async Task<List<EnumOutDto>> GetEnumArray(EnumInDto inDto)
        {
            var db = this._dbContextProvider.GetDbContext();
            string enumType = $"My.D3.Entity.{inDto.Module}.{inDto.EnumTypeName}";
            Assembly autoAssembly = Assembly.Load("My.D3.Entity");
            Type type = autoAssembly.GetType(enumType);

            List<EnumOutDto> enumOutDtos = new List<EnumOutDto>();

            // 获取枚举的描述
            foreach (var value in Enum.GetValues(type))
            {
                EnumOutDto outDto = new EnumOutDto();
                var desc = value.ToString();
                if (desc == "None")
                {
                    desc = string.Empty;
                }

                outDto.Text = desc;
                outDto.Value = (int)value;
                enumOutDtos.Add(outDto);
            }

            return await Task.FromResult(enumOutDtos);
        }
    }
}
