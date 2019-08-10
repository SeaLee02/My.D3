
namespace My.D3.DataAccess.Framework
{
    using Microsoft.EntityFrameworkCore;
    using My.D3.Entity.Demo.View;

    /// <summary>
    /// 数据库对应表
    /// </summary>
	public partial class MyDbContext
    { 
		/// <summary>
        /// 
        /// </summary>
		public DbSet<ViewDemoClass> ViewDemoClass { get; set; }
	 
		/// <summary>
        /// 
        /// </summary>
		public DbSet<ViewDemoCourse> ViewDemoCourse { get; set; }
	 
		/// <summary>
        /// 
        /// </summary>
		public DbSet<ViewDemoSchool> ViewDemoSchool { get; set; }
	 
		/// <summary>
        /// 
        /// </summary>
		public DbSet<ViewDemoStudent2Course> ViewDemoStudent2Course { get; set; }
	 
		/// <summary>
        /// 学生表视图
        /// </summary>
		public DbSet<ViewDemoStudent> ViewDemoStudent { get; set; }
	 
	}
}