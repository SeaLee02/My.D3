﻿namespace My.D3.Application.Repositories.Demo
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using My.D3.Entity.Demo;
    using My.D3.Entity.Framework.Dto;

    /// <summary>
    /// 学生表
    /// </summary>
    [Table("Demo_Student")]
    public partial class DemoStudentResDto : BaseEntityDto<Guid>
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Display(Description = "名称", Name = "名称")]
        [Column("StuName")]
        [StringLength(128)]
        public string StuName { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        [Display(Description = "年龄", Name = "年龄")]
        [Column("Age")]
        public int? Age { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        [Display(Description = "生日", Name = "生日")]
        [Column("Birthday")]
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// 身高
        /// </summary>
        [Display(Description = "身高", Name = "身高")]
        [Column("Height")]
        public decimal? Height { get; set; }

        /// <summary>
        /// 是否VIP
        /// </summary>
        [Display(Description = "是否VIP", Name = "是否VIP")]
        [Column("IsVIP")]
        public byte? IsVIP { get; set; }

        /// <summary>
        /// 班级GUID
        /// </summary>
        [Display(Description = "班级GUID", Name = "班级GUID")]
        [Column("ClassGUID")]
        public Guid? ClassGUID { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [Display(Description = "是否删除", Name = "是否删除")]
        [Column("IsDeleted")]
        public byte IsDeleted { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Description = "创建时间", Name = "创建时间")]
        [Column("CreateTime")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 创建人GUID
        /// </summary>
        [Display(Description = "创建人GUID", Name = "创建人GUID")]
        [Column("CreateGUID")]
        public Guid? CreateGUID { get; set; }

        /// <summary>
        /// 创建人名称
        /// </summary>
        [Display(Description = "创建人名称", Name = "创建人名称")]
        [Column("CreatedName")]
        [StringLength(128)]
        public string CreatedName { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [Display(Description = "修改时间", Name = "修改时间")]
        [Column("ModifiedTime")]
        public DateTime? ModifiedTime { get; set; }

        /// <summary>
        /// 修改人GUID
        /// </summary>
        [Display(Description = "修改人GUID", Name = "修改人GUID")]
        [Column("ModifiedGUID")]
        public Guid? ModifiedGUID { get; set; }

        /// <summary>
        /// 修改人名称
        /// </summary>
        [Display(Description = "修改人名称", Name = "修改人名称")]
        [Column("ModifiedName")]
        [StringLength(128)]
        public string ModifiedName { get; set; }

        /// <summary>
        /// 性别(1.男;2.女)
        /// </summary>
        [Display(Description = "性别(1.男;2.女)", Name = "性别(1.男;2.女)")]
        [Column("SexType")]
        public SexTypeEnum? SexType { get; set; }

    }
}
