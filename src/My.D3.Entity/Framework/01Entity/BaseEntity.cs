﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My.D3.Entity.Framework.Entity
{
    /// <summary>
    /// Entity的基类
    /// </summary>
    /// <typeparam name="TPrimaryKey">entity的主键的类型</typeparam>
    public abstract class BaseEntity<TPrimaryKey> : Entity<TPrimaryKey>
    {
        ///// <summary>
        ///// 是否删除
        ///// </summary>
        //[Column("IsDeleted")]
        //[Display(Name = "是否删除", Description = "是否删除")]
        //public virtual byte IsDeleted { get; set; }

        ///// <summary>
        ///// 创建时间
        ///// </summary>
        //[Column("CreateTime")]
        //[Display(Name = "创建时间", Description = "创建时间")]
        //public virtual DateTime? CreateTime { get; set; }

        ///// <summary>
        ///// 创建人GUID
        ///// </summary>
        //[Column("CreateGUID")]
        //[Display(Name = "创建人GUID", Description = "创建人GUID")]
        //public virtual Guid? CreateGUID { get; set; }

        ///// <summary>
        ///// 创建人名称
        ///// </summary>
        //[Column("CreatedName")]
        //[Display(Name = "创建人名称", Description = "创建人名称")]
        //[StringLength(128)]
        //public virtual string CreatedName { get; set; }

        ///// <summary>
        ///// 修改时间
        ///// </summary>
        //[Column("ModifiedTime")]
        //[Display(Name = "修改时间", Description = "修改时间")]
        //public virtual DateTime? ModifiedTime { get; set; }

        ///// <summary>
        ///// 修改人GUID
        ///// </summary>
        //[Column("ModifiedGUID")]
        //[Display(Name = "修改人GUID", Description = "修改人GUID")]
        //public virtual Guid? ModifiedGUID { get; set; }

        ///// <summary>
        ///// 创建人名称
        ///// </summary>
        //[Column("ModifiedName")]
        //[Display(Name = "修改人名称", Description = "修改人名称")]
        //[StringLength(128)]
        //public virtual string ModifiedName { get; set; }
    }


    /// <summary>
    /// 泛型实体基类
    /// </summary>
    /// <typeparam name="TPrimaryKey">主键</typeparam>
    public abstract class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        /// <summary>
        /// 主键
        /// </summary>
        public virtual TPrimaryKey Id { get; set; }

        /// <summary>
        /// 是否有值
        /// </summary>
        /// <returns></returns>
        public virtual bool IsTransient()
        {
            if (EqualityComparer<TPrimaryKey>.Default.Equals(Id, default(TPrimaryKey)))
            {
                return true;
            }

            if (typeof(TPrimaryKey) == typeof(int))
            {
                return Convert.ToInt32(Id) <= 0;
            }

            if (typeof(TPrimaryKey) == typeof(long))
            {
                return Convert.ToInt64(Id) <= 0;
            }

            return false;
        }


        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }


    public interface IEntity<TPrimaryKey>
    {

        TPrimaryKey Id { get; set; }

        bool IsTransient();
    }

}
