using My.D3.Application.Test.TestDatas.DataInit;
using My.D3.DataAccess.Framework;
using My.D3.Util.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace My.D3.Application.Test.TestDatas
{
    public class TestDataBuilder
    {
        private readonly MyDbContext _context;

        public TestDataBuilder(MyDbContext context)
        {
            this._context = context;
        }

        public void Build()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            List<Type> initTypes = assembly.GetAllChildType(typeof(BaseInit));

            foreach (var type in initTypes)
            {
                var initType = Activator.CreateInstance(type) as BaseInit;
                initType.Excute(this._context);
            }
        }
    }
}