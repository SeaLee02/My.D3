namespace My.D3.Entity.Demo.Function
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using Sealee.SqlHelper;
	using My.D3.Framework;

	/// <summary>
    /// 
    /// </summary>
    public class FnDemoStringFormat 
    {

        /// <summary>
        /// 
        /// </summary>
        public string @Str { get; set; } 

        /// <summary>
        /// 
        /// </summary>
        public string @Param1 { get; set; } 

        /// <summary>
        /// 
        /// </summary>
        public string @Param2 { get; set; } 

        /// <summary>
        /// 
        /// </summary>
        public string @Param3 { get; set; } 

        /// <summary>
        /// 
        /// </summary>
        public string @Param4 { get; set; } 

        /// <summary>
        /// 
        /// </summary>
        public string @Param5 { get; set; } 

        /// <summary>
        /// 获取单个值
        /// </summary>
        /// <typeparam name="T">值得类型</typeparam>
        /// <returns>单个值</returns>
        public T ExecuteScalar<T>()
        {
            var conStr = _MyConfig.ConnectionString;
            string sql = this.GetSql();
            return DBHelper.ExecuteScalar<T>(conStr, sql, null);
        }

        public string GetSql()
        {
            string sql = "SELECT dbo.fn_Demo_StringFormat(";
            sql += $"'{this.@Str}',";
            sql += $"'{this.@Param1}',";
            sql += $"'{this.@Param2}',";
            sql += $"'{this.@Param3}',";
            sql += $"'{this.@Param4}',";
            sql += $"'{this.@Param5}',";
            sql = sql.Substring(0, sql.Length - 1);
            sql+=");";
            return sql;
        }

	}
}
