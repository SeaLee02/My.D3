namespace My.D3.Entity.Framework.Dto
{
    /// <summary>
    /// Entity的基类
    /// </summary>
    /// <typeparam name="TPrimaryKey">entity的主键的类型</typeparam>
    public abstract class BaseEntityDto<TPrimaryKey> : EntityDto<TPrimaryKey>
    {

    }

    /// <summary>
    /// 泛型Dto基类
    /// </summary>
    /// <typeparam name="TPrimaryKey">主键</typeparam>
    public abstract class EntityDto<TPrimaryKey> : IEntityDto<TPrimaryKey>
    {
        /// <summary>
        /// 主键
        /// </summary>
        public virtual TPrimaryKey Id { get; set; }
    }

    public interface IEntityDto<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}
