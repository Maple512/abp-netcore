﻿namespace AbpLearning.Core.CloudBookLists.BookLists
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Abp.Domain.Entities;
    using Abp.Domain.Entities.Auditing;
    using AbpLearning.Core.Authorization.Users;
    using BookListCells;

    /// <summary>
    /// 书单
    /// </summary>
    [Table(AbpLearningConsts.TablePreFixName.CloudBookList + nameof(BookList), Schema = AbpLearningConsts.TableSchemaName.CloudBookList)]
    public class BookList : FullAuditedEntity<long, User>, IMayHaveTenant
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
        public string Name { get; private set; }

        /// <summary>
        /// 简介
        /// </summary>
        [MaxLength(128)]
        public string Intro { get; private set; }

        /// <summary>
        /// 书单中存在的格子（即书籍）的数量
        /// </summary>
        public int ExsitedBookCount => Cells.Count;

        /// <summary>
        /// <see cref="BookListCell"/>'s
        /// </summary>
        [Range(0, CellMaxLength)]
        public virtual ICollection<BookListCell> Cells { get; set; }

        public int? TenantId { get; set; }
    }
}
