namespace My.D3.DataAccess.Framework
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;
    using My.D3.DataAccess.Framework.Configuration;
    using System.Collections.Generic;

    public partial class MyDbContext : DbContext
    {

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            DbFilterConfiguration.InitContextFilter(this);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            IEnumerable<IMutableEntityType> entityTypes = modelBuilder.Model.GetEntityTypes();
            foreach (IMutableEntityType entityType in entityTypes)
            {
                //初始化过滤器
                DbFilterConfiguration.InitGobalFilter(entityType, modelBuilder);
                //ViewConfiguration.InitViews(entityType); // 初始化视图
            }
        }


        //需要ioc的
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(@"server=.;database=MyCoreDB;uid=sa;pwd=123");
        //    }
        //}

    }
}
