namespace My.D3.Application.PublicService.AppServices.Enum
{
    /// <summary>
    /// 获取枚举输出Dto
    /// </summary>
    public class EnumOutDto
    {
        /// <summary>
        /// 枚举描述
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 枚举的值
        /// </summary>
        public int Value { get; set; }
    }

    /// <summary>
    /// 获取枚举输入Dto
    /// </summary>
    public class EnumInDto
    {
        /// <summary>
        /// 枚举类型的值
        /// </summary>
        public string EnumTypeName { get; set; }

        /// <summary>
        /// 模块的值
        /// </summary>
        public string Module { get; set; }
    }
}
