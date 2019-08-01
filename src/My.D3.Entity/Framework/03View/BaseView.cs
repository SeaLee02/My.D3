namespace My.D3.Entity.Framework.View
{
    using My.D3.Entity.Framework.Entity;

    /// <summary>
    /// View的基类
    /// </summary>
    /// <typeparam name="TPrimaryKey">entity的主键的类型</typeparam>
    public abstract class BaseView<TPrimaryKey> : Entity<TPrimaryKey>
    {

    }
}
