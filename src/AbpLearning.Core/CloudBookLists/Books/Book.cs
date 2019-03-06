namespace AbpLearning.Core.CloudBookLists.Books
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Abp.Collections.Extensions;
    using Abp.Domain.Entities;
    using Abp.Domain.Entities.Auditing;
    using Abp.Json;
    using AbpLearning.Core.Authorization.Users;

    /// <summary>
    /// 书籍
    /// TODO:待优化 数据结构
    /// </summary>
    [Table(AbpLearningConsts.TablePreFixName.CloudBookList + nameof(Book), Schema = AbpLearningConsts.TableSchemaName.CloudBookList)]
    public class Book : FullAuditedEntity<long, User>, IMayHaveTenant
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

        public Book(string name, string author, string coverImgUrl = null, string intro = null, string url = null, int? tenantId = null)
        {
            CoverImgUrl = coverImgUrl;
            Name = name;
            Author = author;
            Intro = intro;
            Url = url;
            TenantId = tenantId;
        }

        /// <summary>
        /// 封面图片
        /// </summary>
        [MaxLength(CoverImgUrlMaxLength)]
        [DataType(DataType.Url)]
        public string CoverImgUrl { get; private set; }

        /// <summary>
        /// 书名
        /// </summary>
        [Required]
        [MaxLength(BookNameMaxLength)]
        public string Name { get; private set; }

        /// <summary>
        /// 作者
        /// </summary>
        [Required]
        [MaxLength(AuthorMaxLength)]
        public string Author { get; private set; }

        /// <summary>
        /// 简介
        /// </summary>
        [MaxLength(IntroMaxLength)]
        public string Intro { get; private set; }

        /// <summary>
        /// 购买/详情 链接
        /// </summary>
        [MaxLength(BookUrlMaxLength)]
        [DataType(DataType.Url)]
        public string Url { get; private set; }

        /// <summary>
        /// tag's
        /// </summary>
        public List<string> Tags => TagJSON.FromJsonString<List<string>>();

        /// <summary>
        /// tag JSON string
        /// </summary>
        public string TagJSON { get; private set; }

        public int? TenantId { get; set; }

        /// <summary>
        /// add/remove tag's for entity
        /// </summary>
        /// <param name="tags"></param>
        public void AddOrRemoveTags(IEnumerable<string> tags)
        {
            if (tags.Count() == 0)
            {
                return;
            }

            tags = tags.OrderBy(m => m).Distinct();

            TagJSON = tags.ToJsonString();
        }
    }
}
