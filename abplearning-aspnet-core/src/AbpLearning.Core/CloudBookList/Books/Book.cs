namespace AbpLearning.Core.CloudBookList.Books
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Abp.Domain.Entities;
    using Abp.Domain.Entities.Auditing;
    using AbpLearning.Core.Authorization.Users;
    using BookTags;

    /// <summary>
    /// 书籍
    /// </summary>
    public class Book : AuditedEntity<long, User>, IMayHaveTenant, ISoftDelete
    {
        /// <summary>
        /// <see cref="Book"/>拥有<see cref="BookTag"/>的最大数量
        /// </summary>
        public const byte TagsMaxLength = 10;

        public Book(string name, string author, string coverImgUrl = null, string intro = null, string url = null, int? tenantId = null, bool isDeleted = false)
        {
            CoverImgUrl = coverImgUrl;
            Name = name;
            Author = author;
            Intro = intro;
            Url = url;
            TenantId = tenantId;
            IsDeleted = isDeleted;
        }

        /// <summary>
        /// 封面图片
        /// </summary>
        [MaxLength(128)]
        [DataType(DataType.Url)]
        public string CoverImgUrl { get; set; }

        /// <summary>
        /// 书名
        /// </summary>
        [Required]
        [MaxLength(32)]
        public string Name { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        [Required]
        [MaxLength(32)]
        public string Author { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        [MaxLength(512)]
        public string Intro { get; set; }

        /// <summary>
        /// 购买/详情 链接
        /// </summary>
        [MaxLength(128)]
        [DataType(DataType.Url)]
        public string Url { get; set; }

        /// <summary>
        /// <see cref="BookTag"/>'s
        /// </summary>
        /// [Index]
        [Range(0, TagsMaxLength)]
        public virtual ICollection<BookTag> Tags { get; set; }

        public int? TenantId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
