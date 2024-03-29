﻿namespace My.D3.Entity.Demo.View
{
    using System;   
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using My.D3.Entity.Framework.View;

    /// <summary>
    /// 
    /// </summary>
    [Table("View_Demo_Class")]
    public partial class ViewDemoClass : BaseView<Guid>
    {
		/// <summary>
        /// 班级GUID
        /// </summary>
        [Display(Description = "班级GUID", Name = "班级GUID")]
        [Column("ClassGUID")]
        public override Guid Id { get; set; }

		/// <summary>
        /// 班级名称
        /// </summary>
        [Display(Description = "班级名称", Name = "班级名称")]
        [Column("ClassName")]
        [StringLength(256)]
        public string  ClassName { get; set; }

		/// <summary>
        /// 学院GUID
        /// </summary>
        [Display(Description = "学院GUID", Name = "学院GUID")]
        [Column("SchoolGUID")]
        public Guid?  SchoolGUID { get; set; }

		/// <summary>
        /// 是否删除
        /// </summary>
        [Display(Description = "是否删除", Name = "是否删除")]
        [Column("IsDeleted")]
        public byte  IsDeleted { get; set; }

		/// <summary>
        /// 创建时间
        /// </summary>
        [Display(Description = "创建时间", Name = "创建时间")]
        [Column("CreateTime")]
        public DateTime?  CreateTime { get; set; }

		/// <summary>
        /// 创建人GUID
        /// </summary>
        [Display(Description = "创建人GUID", Name = "创建人GUID")]
        [Column("CreateGUID")]
        public Guid?  CreateGUID { get; set; }

		/// <summary>
        /// 创建人名称
        /// </summary>
        [Display(Description = "创建人名称", Name = "创建人名称")]
        [Column("CreatedName")]
        [StringLength(128)]
        public string  CreatedName { get; set; }

		/// <summary>
        /// 修改时间
        /// </summary>
        [Display(Description = "修改时间", Name = "修改时间")]
        [Column("ModifiedTime")]
        public DateTime?  ModifiedTime { get; set; }

		/// <summary>
        /// 修改人GUID
        /// </summary>
        [Display(Description = "修改人GUID", Name = "修改人GUID")]
        [Column("ModifiedGUID")]
        public Guid?  ModifiedGUID { get; set; }

		/// <summary>
        /// 修改人名称
        /// </summary>
        [Display(Description = "修改人名称", Name = "修改人名称")]
        [Column("ModifiedName")]
        [StringLength(128)]
        public string  ModifiedName { get; set; }

    }
}

