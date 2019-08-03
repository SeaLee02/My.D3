namespace Test.T4
{
    using System.Collections.Generic;
    using System;
    using Sealee.SqlHelper;
	using My.D3.Framework;

	/// <summary>
    /// 
    /// </summary>
    public class FnDemoGetDays 
    {
        /// <summary>
        /// 
        /// </summary>
        public DateTime @StartDate { get; set; } 

        /// <summary>
        /// 
        /// </summary>
        public DateTime @EndDate { get; set; } 

         /// <summary>
        /// 获取List集合
        /// </summary>
        /// <returns>list集合</returns>
        public List<FnDemoGetDaysTableInfo> QueryList()
        {
            var conStr =_MyConfig.ConnectionString;
            string sql = this.GetSql();
            return DBHelper.QueryList<FnDemoGetDaysTableInfo>(conStr, sql, null);
        }

        public string GetSql()
        {
            string sql = "SELECT dbo.fn_Demo_GetDays(";
            sql += $"'{this.@StartDate}',";
            sql += $"'{this.@EndDate}',";
            sql = sql.Substring(0, sql.Length - 1);
            sql+=");";
            return sql;
        }


	}

    public class  FnDemoGetDaysTableInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public DateTime Days { get; set; } 


    }

}
