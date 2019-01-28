namespace AbpLearning.Core.CloudBookLists.Books
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Abp.Domain.Entities;
    using Abp.Domain.Entities.Auditing;
    using AbpLearning.Core.Authorization.Users;
    using BookTags;

    /// <summary>
    /// 书籍
    /// </summary>
    [Table(AbpLearningConsts.TablePreFixName.CloudBookList + nameof(Book), Schema = AbpLearningConsts.TableSchemaName.CloudBookList)]
    public class Book : AuditedEntity<long, User>, IMayHaveTenant, ISoftDelete
    {

        public const int TagsMaxLength = 10;

        /// <summary>
        /// 书籍分页，展示最多数量的书签
        /// </summary>
        public const int BookPageShowTagMaxLenght = 5;

        public const int CoverImgUrlMaxLength = 128;

        public const int BookNameMaxLength = 32;

        public const int AuthorMaxLength = 32;

        public const int IntroMaxLength = 512;

        public const int BookUrlMaxLength = 64;

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
        [MaxLength(CoverImgUrlMaxLength)]
        [DataType(DataType.Url)]
        public string CoverImgUrl { get; set; }

        /// <summary>
        /// 书名
        /// </summary>
        [Required]
        [MaxLength(BookNameMaxLength)]
        public string Name { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        [Required]
        [MaxLength(AuthorMaxLength)]
        public string Author { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        [MaxLength(IntroMaxLength)]
        public string Intro { get; set; }

        /// <summary>
        /// 购买/详情 链接
        /// </summary>
        [MaxLength(BookUrlMaxLength)]
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
