namespace AbpLearning.Core.CloudBookLists.BookLists
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Abp.Domain.Entities;
    using Abp.Domain.Entities.Auditing;
    using AbpLearning.Core.Authorization.Users;
    using BookLiseCells;

    /// <summary>
    /// 书单
    /// </summary>
    public class BookList : AuditedEntity<long, User>, IMayHaveTenant, ISoftDelete
    {
        /// <summary>
        /// 允许的最大格子（1格子/书）数量
        /// </summary>
        public const byte CellMaxLength = 20;

        public BookList(string name, string intro = null, int? tenantId = null)
        {
            Name = name;
            Intro = intro;
            TenantId = tenantId;
        }

        /// <summary>
        /// 书单名
        /// </summary>
        [Required]
        [MaxLength(32)]
        public string Name { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        [MaxLength(128)]
        public string Intro { get; set; }

        /// <summary>
        /// <see cref="BookListCell"/>'s
        /// </summary>
        [Range(0, CellMaxLength)]
        public virtual ICollection<BookListCell> Cells { get; set; }

        public int? TenantId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
