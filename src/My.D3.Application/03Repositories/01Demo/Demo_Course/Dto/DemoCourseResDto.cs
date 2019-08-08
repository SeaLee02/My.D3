namespace My.D3.Application.Repositories.Demo
{
    using System;
    using System.ComponentModel;   
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using My.D3.Entity.Framework.Dto;

    /// <summary>
    /// 课程表
    /// </summary>
    [Table("Demo_Course")]
    public partial class DemoCourseResDto : BaseEntityDto<Guid>
    {
        /// <summary>
        /// 课程名称
        /// </summary>
        [Display(Description = "课程名称", Name = "课程名称")]
		[Column("CourseName")]
        [StringLength(256)]
        public string  CourseName { get; set; }

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
