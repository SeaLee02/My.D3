namespace My.D3.Application.Test.TestDatas.DataInit
{
    using My.D3.DataAccess.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class BaseInit
    {
        public abstract void Excute(MyDbContext context);
    }
}

