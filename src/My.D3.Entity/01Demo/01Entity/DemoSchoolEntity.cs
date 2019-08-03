namespace My.D3.Entity.Demo
{
    using System;
    using System.ComponentModel;   
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using My.D3.Entity.Framework.Entity;

    /// <summary>
    /// 学院表
    /// </summary>
    [Table("Demo_School")]
    public partial class DemoSchoolEntity : BaseEntity<Guid>
    {

        /// <summary>
        /// 主键
        /// </summary>
        [Column("SchoolGUID")]
        [Display(Name = "学院表主键", Description = "学院表主键")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override Guid Id { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        [Display(Description = "编码", Name = "编码")]
		[Column("SchoolCode")]
        [StringLength(512)]
        public string  SchoolCode { get; set; }

        /// <summary>
        /// 学校名称
        /// </summary>
        [Display(Description = "学校名称", Name = "学校名称")]
		[Column("SchoolName")]
        [StringLength(512)]
        public string  SchoolName { get; set; }

        /// <summary>
        /// 父级GUID
        /// </summary>
        [Display(Description = "父级GUID", Name = "父级GUID")]
		[Column("ParentSchoolGUID")]
        public Guid?  ParentSchoolGUID { get; set; }

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
