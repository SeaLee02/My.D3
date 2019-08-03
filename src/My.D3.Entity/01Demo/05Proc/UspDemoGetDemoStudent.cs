namespace My.D3.Entity.Demo.Pro
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;            
    using My.D3.Entity.Framework.Pro;
    
     /// <summary>
    /// 
    /// </summary>
    public class UspDemoGetDemoStudent : BasePro
    {
	
        
        /// <summary>
        /// 
        /// </summary>
        public string @StuName { get; set; } 

        
        /// <summary>
        /// 
        /// </summary>
        public int @OutCount { get; set; } 

                                               
        public override SqlParameter[] GetSqlParameters()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@StuName", this.StuName));
            var paramOutCount = new SqlParameter("@OutCount", SqlDbType.Int);
            paramOutCount.Direction = ParameterDirection.Output;
            parameters.Add(paramOutCount);
            return parameters.ToArray();
         }

        public override string GetSql()
        {
            string sql = "EXEC dbo.usp_Demo_GetDemoStudent ";
            sql += " @StuName =@StuName,";
            sql += " @OutCount =@OutCount OUT,";
            sql = sql.Substring(0, sql.Length - 1);
            return sql;
        }

	}
}
