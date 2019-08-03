namespace My.D3.Entity.Demo.Dto
{
    using System;
    using System.ComponentModel;   
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using My.D3.Entity.Framework.Dto;

    /// <summary>
    /// 学生课程表
    /// </summary>
    [Table("Demo_Student2Course")]
    public partial class DemoStudent2CourseDto : BaseEntityDto<Guid>
    {

        /// <summary>
        /// 主键
        /// </summary>
        [Column("CourseGUID")]
        [Display(Name = "学生课程表主键", Description = "学生课程表主键")]
        public override Guid Id { get; set; }

        /// <summary>
        /// 分数
        /// </summary>
        [Display(Description = "分数", Name = "分数")]
		[Column("Score")]
        public decimal?  Score { get; set; }

        /// <summary>
        /// 学生课程GUID
        /// </summary>
        [Display(Description = "学生课程GUID", Name = "学生课程GUID")]
		[Column("Student2CourseGUID")]
        public Guid?  Student2CourseGUID { get; set; }

        /// <summary>
        /// 学生GUID
        /// </summary>
        [Display(Description = "学生GUID", Name = "学生GUID")]
		[Column("StudentGUID")]
        public Guid?  StudentGUID { get; set; }

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
