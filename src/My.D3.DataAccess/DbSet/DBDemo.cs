
namespace MyCore.DataAccess.Framework
{
    using Microsoft.EntityFrameworkCore;
    using My.D3.Entity.Demo;

    /// <summary>
    /// 数据库对应表
    /// </summary>
	public partial class MyDbContext
    { 
		/// <summary>
        /// 班级表
        /// </summary>
		public DbSet<DemoClassEntity> DemoClass { get; set; }
	 
		/// <summary>
        /// 课程表
        /// </summary>
		public DbSet<DemoCourseEntity> DemoCourse { get; set; }
	 
		/// <summary>
        /// 学院表
        /// </summary>
		public DbSet<DemoSchoolEntity> DemoSchool { get; set; }
	 
		/// <summary>
        /// 学生表
        /// </summary>
		public DbSet<DemoStudentEntity> DemoStudent { get; set; }
	 
		/// <summary>
        /// 学生课程表
        /// </summary>
		public DbSet<DemoStudent2CourseEntity> DemoStudent2Course { get; set; }
	 
	}
}