//namespace My.D3.Application.Test.TestDatas
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;
//    using System.Text;
//    using System.Threading.Tasks;
//    using My.D3.Application.Test.TestDatas.DataInit;
//    using My.D3.DataAccess.Framework;
//    using My.D3.Entity.Demo;

//    /// <summary>
//    /// 学生表数据初始化（仅供单元测试使用,数据是存储在内存中的）
//    /// </summary>
//    public class TemplateInit : BaseInit
//    {
//        /// <summary>
//        /// 学生表数据初始化
//        /// </summary>
//        /// <param name="context">内存中的数据</param>
//        public override void Excute(MyDbContext context)
//        {
//            List<DemoStudentEntity> entitys = new List<DemoStudentEntity>()
//            {
//                //new DemoStudentEntity()
//                //{
//                //     StuName="ceshi"
//                //}
//            };
//            context.DemoStudent.AddRange(entitys);
//            context.SaveChanges();
//        }
//    }
//}
